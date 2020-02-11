using Ionic.Zip;
using System.Collections.Generic;

public static class ZipHelper
{
    public static void UnZip(string file, string unZipTo)
    {
        try
        {
            // Specifying Console.Out here causes diagnostic msgs to be sent to the Console
            // In a WinForms or WPF or Web app, you could specify nothing, or an alternate
            // TextWriter to capture diagnostic messages.

            using (ZipFile zip = ZipFile.Read(file))
            {
                // This call to ExtractAll() assumes:
                //   - none of the entries are password-protected.
                //   - want to extract all entries to current working directory
                //   - none of the files in the zip already exist in the directory;
                //     if they do, the method will throw.
                zip.ExtractAll(unZipTo, ExtractExistingFileAction.OverwriteSilently);
            }
        }
        catch (System.Exception)
        {
        }
    }

    public static void ZipaFile(string file, string zipFile)
    {
        using (ZipFile zip = new ZipFile())
        {
            zip.AddFile(file, "");
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
            zip.Save(zipFile);
        }
    }

    public static void ZipFiles(List<string> files, string zipFile)
    {
        using (ZipFile zip = new ZipFile())
        {
            zip.AddFiles(files, false, "");
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
            zip.Save(zipFile);
        }
    }

    public static void ZipDirectory(string directory, string zipFile)
    {
        using (ZipFile zip = new ZipFile())
        {
            zip.AddDirectory(directory);
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
            zip.Save(zipFile);
        }
    }
}