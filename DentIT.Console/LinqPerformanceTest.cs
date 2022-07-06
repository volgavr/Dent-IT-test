using BenchmarkDotNet.Attributes;

namespace DentIT.Console
{
    public class LinqPerformanceTest
    {
        const int RangeSize = 500000;

        [Benchmark]
        public void Method1()
        {
            var rand = new Random();
            var receptions = Enumerable.Range(1, RangeSize).SelectMany(pid => Enumerable.Range(1, rand.Next(0, 100)).Select(rid => new { PatientId = pid, ReceptionStart = new DateTime(2017, 06, 30).AddDays(-rand.Next(1, 500)) })).ToList();
            var patients = Enumerable.Range(1, RangeSize).Select(pid => new { Id = pid, Surname = string.Format("Иванов {0}", pid) }).ToList();

            var result = patients.Join(
                receptions.Where(r => r.ReceptionStart < new DateTime(2017, 1, 1)),
                p => p.Id,
                r => r.PatientId, (p, r) => p).DistinctBy(p => p.Id).ToList();
        }

        [Benchmark]
        public void Method2()
        {
            var rand = new Random();
            var receptions = Enumerable.Range(1, RangeSize).SelectMany(pid => Enumerable.Range(1, rand.Next(0, 100)).Select(rid => new { PatientId = pid, ReceptionStart = new DateTime(2017, 06, 30).AddDays(-rand.Next(1, 500)) })).ToList();
            var patients = Enumerable.Range(1, RangeSize).Select(pid => new { Id = pid, Surname = string.Format("Иванов {0}", pid) }).ToList();

            patients.Join(
                receptions.Where(r => r.ReceptionStart < new DateTime(2017, 1, 1)).Select(r => r.PatientId).Distinct(),
                p => p.Id,
                r => r,
                (p, r) => p).ToList();

        }

        [Benchmark]
        public void Method3()
        {
            var rand = new Random();
            var receptions = Enumerable.Range(1, RangeSize).SelectMany(pid => Enumerable.Range(1, rand.Next(0, 100)).Select(rid => new { PatientId = pid, ReceptionStart = new DateTime(2017, 06, 30).AddDays(-rand.Next(1, 500)) })).ToList();
            var patients = Enumerable.Range(1, RangeSize).Select(pid => new { Id = pid, Surname = string.Format("Иванов {0}", pid) }).ToList();

            patients.Join(
                receptions.Where(r => r.ReceptionStart < new DateTime(2017, 1, 1)).GroupBy(r => r.PatientId),
                p => p.Id,
                gr => gr.Key,
                (p, gr) => p).ToList();
        }
    }
}
