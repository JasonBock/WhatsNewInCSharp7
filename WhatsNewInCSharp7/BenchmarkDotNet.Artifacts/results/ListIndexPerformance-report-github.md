``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i7-5600U CPU 2.60GHz (Broadwell), ProcessorCount=4
Frequency=2533193 Hz, Resolution=394.7587 ns, Timer=TSC
  [Host]     : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2101.1
  DefaultJob : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2101.1


```
 |              Method |       Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |-------------------- |-----------:|----------:|----------:|-------:|---------:|----------:|
 | GetNameFromFastList |  0.4910 ns | 0.0549 ns | 0.0855 ns |   1.00 |     0.00 |       0 B |
 | GetNameFromSlowList | 18.8409 ns | 0.4125 ns | 0.8045 ns |  39.47 |     6.76 |       0 B |
