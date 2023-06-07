// See https://aka.ms/new-console-template for more information
using SequentialNumericUUID;

Console.WriteLine("  Generate 100 Sequential Numbers:-");
for (int i = 0; i < 100; i++)
{
    ulong nanoSecondsTimeStamp = SequentialNumericUID.Generate();
    ulong randomNanoSecondsTimeStamp = SequentialNumericUID.GenerateWithRandomnessInNanoSecondScope();
    Console.WriteLine("Nano Timestamp:       " + nanoSecondsTimeStamp);
    Console.WriteLine("Random Nano Timestamp:" + randomNanoSecondsTimeStamp);
    Console.WriteLine("Date UTC :" + SequentialNumericUID.GetUTCDateTime(nanoSecondsTimeStamp).ToString());
    Console.WriteLine("Date UTC :" + SequentialNumericUID.GetUTCDateTime(randomNanoSecondsTimeStamp, true).ToString());
    Console.WriteLine();
}


