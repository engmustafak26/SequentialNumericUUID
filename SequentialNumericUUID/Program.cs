// See https://aka.ms/new-console-template for more information
using SequentialNumericUUID;


Console.WriteLine("  Generate 100 Sequential Numbers:-");
for (int i = 0; i < 100; i++)
{
    ulong nanoSecondsTimeStamp = SequentialNumericUID.Generate();
    Console.WriteLine("Nano Timestamp: "+nanoSecondsTimeStamp);
    Console.WriteLine("Date UTC :"+SequentialNumericUID.GetUTCDateTime(nanoSecondsTimeStamp).ToString());
    Console.WriteLine();
}


