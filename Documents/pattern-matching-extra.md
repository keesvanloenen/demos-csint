# Pattern Matching Extra

A logistics company needs to categorize shipments using C# pattern matching.

You are given the following record:

```cs
record Shipment(double WeightKg, string Destination, bool IsExpress);
``` 

Write a switch expression that assigns a string category based on these rules:

- Shipments with a weight less than 1 kg → "Light package"
- Shipments with a weight between 1 kg (inclusive) and 10 kg → "Standard package"
- Shipments with a weight of 10 kg or more that are express → "Heavy express shipment"
- Shipments with a weight of 10 kg or more that are not express → "Heavy standard shipment"
- Any other case → "Unknown"