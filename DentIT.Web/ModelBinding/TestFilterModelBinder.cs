using DentIT.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DentIT.Web.ModelBinding
{
    public class TestFilterModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var modelName = bindingContext.ModelName;
            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            var splitVal = value.Split(new char[] { '.' });
            if (splitVal.Length == 2)
            {
                bool monthValid = int.TryParse(splitVal[0], out var month);
                bool yearValid = int.TryParse(splitVal[1], out var year);

                if (monthValid && yearValid)
                {
                    var result = new TestFilter();                    
                    bindingContext.Result = ModelBindingResult.Success(result);
                    
                    if (month >= 1 && month <= 12 && year >= 1 && year <= 9999)
                        result.YearMonth = new YearMonth { Month = month, Year = year };
                    else
                        // Non-valid arguments result in model state errors
                        bindingContext.ModelState.TryAddModelError(
                            "YearMonth", "Month or year value is out of range.");
                }
            }

            return Task.CompletedTask;
        }
    }
}
