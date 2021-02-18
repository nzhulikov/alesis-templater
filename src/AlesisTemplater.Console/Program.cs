using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlesisTemplater.Console
{
    public class Program
    {
        private static readonly HashSet<int> ChannelIndices = new HashSet<int> { 28, 56, 57, 69, 64, 74, 79, 84, 89, 94, 99, 104, 109, 114, 119, 124, 129, 134, 139, 144, 149, 154, 159, 164, 169, 174, 179, 184, 189, 194, 199, 204, 209, 214, 219, 224, 229, 234, 239, 244, 249, 254, 259, 264, 269, 274, 279, 284, 289, 294, 299, 304, 309, 314, 319, 324, 329, 334, 339, 344, 349, 354, 359, 364, 369, 374, 379, 384 };
        private const int TemplateSize = 0x18c;
        private const byte MaxChannel = 0xF;

        private static void Main(string[] args)
        {
            var templatePath = args[0];
            var templateBytes = GetTemplateBytes(templatePath);
            for (byte channel = 0; channel <= MaxChannel; channel++)
            {
                var preset = GeneratePreset(channel, templateBytes);
                SaveTemplate(preset, $"preset_ch{channel + 1:00}.vi4");
            }
        }

        private static byte[] GetTemplateBytes(string templatePath)
        {
            using var file = File.Open(templatePath, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(file);
            var templateBytes = reader.ReadBytes(TemplateSize);
            return templateBytes;
        }

        private static void SaveTemplate(byte[] preset, string name)
        {
            using var file = File.Open(name, FileMode.Create, FileAccess.Write);
            using var writer = new BinaryWriter(file, Encoding.BigEndianUnicode);
            writer.Write(preset);
        }

        private static byte[] GeneratePreset(byte channel, IReadOnlyList<byte> template)
        {
            var preset = new byte[TemplateSize];
            for (var i = 0; i < template.Count; i++)
            {
                if (ChannelIndices.Contains(i))
                {
                    preset[i] = channel;
                } else
                {
                    preset[i] = template[i];
                }
            }

            return preset;
        }
    }
}