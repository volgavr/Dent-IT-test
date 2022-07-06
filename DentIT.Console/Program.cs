// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;

Console.WriteLine("--- starting ----");
/*var rand = new Random();
var receptions = Enumerable.Range(1, 500000).SelectMany(pid => Enumerable.Range(1, rand.Next(0, 100)).Select(rid => new { PatientId = pid, ReceptionStart = new DateTime(2017, 06, 30).AddDays(-rand.Next(1, 500)) })).ToList();
var patients = Enumerable.Range(1, 500000).Select(pid => new { Id = pid, Surname = string.Format("Иванов {0}", pid) }).ToList();
;
Console.WriteLine($"receptions: {receptions.Count}; patients: { patients.Count }");
var rec2016 = receptions.Where(r => r.ReceptionStart < new DateTime(2017, 1, 1));//.GroupBy(r => r.PatientId);
//var rec2016 = receptions.Where(r => r.ReceptionStart < new DateTime(2017, 1, 1)).Select(r => r.PatientId).Distinct().ToArray();
//Console.WriteLine($"receptions (pr 2017): {rec2016.Length}");
Console.WriteLine($"receptions (pr 2017): {rec2016.Count()}");

//var innerJoined1 = patients.Join(rec2016, p => p.Id, r => r, (p, r) => p);
var innerJoined1 = patients.Join(rec2016, p => p.Id, gr => gr.PatientId, (p, gr) => p);
Console.WriteLine($"patients (pr 2017): {innerJoined1.Count()}");

var innerJoinedDistict = innerJoined1;// DistinctBy(p => p.Id).ToList();
Console.WriteLine($"patients (pr 2017 distinct): {innerJoinedDistict.Count()}");
;

var result0 = patients.Join(
    receptions.Where(r => r.ReceptionStart < new DateTime(2017, 1, 1)),
    p => p.Id,
    r => r.PatientId, (p, r) => p).DistinctBy(p => p.Id).ToList();

var result1 =
patients.Join(
    receptions.Where(r => r.ReceptionStart < new DateTime(2017, 1, 1)).GroupBy(r => r.PatientId),
    p => p.Id,
    gr => gr.Key,
    (p, gr) => p).ToList();
*/
//var result =
//patients.Join(
//    receptions.Where(r => r.ReceptionStart < new DateTime(2017, 1, 1)).Select(r => r.PatientId).Distinct(),
//    p => p.Id,
//    r => r,
//    (p, r) => p).ToList();

//Console.WriteLine($"patients (pr 2017 result): {result0.Count}");
//Console.WriteLine($"patients (pr 2017 result): {result1.Count}");
//Console.WriteLine($"patients (pr 2017 result): {result.Count}");

BenchmarkRunner.Run<DentIT.Console.LinqPerformanceTest>();