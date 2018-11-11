using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace random_data_generator
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Random data generator"),
        ExportMetadata("Description", "Need to mock some data? This tool allows you to generate entity records with randomized data."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAQAAADZc7J/AAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAAAmJLR0QAAKqNIzIAAAAJcEhZcwAADdcAAA3XAUIom3gAAAAHdElNRQfiCwsUGQ3JF3gwAAABnUlEQVRIx62VwUoCURSGvzGFWo0tXJRtJEEIhGnVRkgfQBzfQPABXLloVa1atMieQN9AfQODNq4cEAKhaBaZixbhqkBiWszVrnrnNmH/6uecwz+c/9xzxsBDh13gXVcQBb54Ueb2iQk241VZccAWeLgB4g4eceJ4OAEVLl5EEU5iYa5FTSySgqew2PGpSqDOgMJatMCAuuA3DMj8eLCKIV0ma9EJXYaC94HpPCF7kKaCpfXAokI62IMcTWx0sGmSkwPLLThc0tMK9GB1Jn4LSRpUV4qXW8jSoCwyVRokl1tIUKOo/fYhNU4FL1IjsdzCM2WF8zL6lHkS/IoWz6op6FpQwcUz8JjxoExn2BbL9MlIWXFEzNh0Gw3iWoEpKPZCQoQNsXELUdCa6ENj4r8dFBObE8Gz2OyF9WAukKLNmeBV2guxXzF/ym/cLs7FHSwebQj8zYM8F9LJCTiqOuQ5lwRQ30QdOrjcq03sSCZ2Ak10aPGoEjApSWMshR/jvIURx4tDfS2fi7ACH5LTY8bhTTHwtD9Xf5k0P9eNt/EbKBCC7bw890wAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTgtMTEtMTFUMjA6MjU6MTMrMDE6MDBCpFNNAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE4LTExLTExVDIwOjI1OjEzKzAxOjAwM/nr8QAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAYAAACOEfKtAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAOQSURBVHhe7Zyxr0xBFMYfUSgUCoVCoVDQKSQIEhIFiYKORKMjUdDxP+gpFRIKCYVCIUFIKEgUEgqFQqGQUCgUEr5v57mZOXuvO7vn7uy8d79f8ntv3svOvsl5u3Nmzp27K+BPhd6FFv6u7bFLdSO+CAcKoBMF0MkGyPdyzGf4LjSLsBUeDc2Ge/BcaDZwDjwbmhN+wWer30vBcXK8CXZifABLsh1+h/EYcpII+7BvSRibeAxKIl4UQCcKoJO2JPIQnglNN/vg8dBsYIJgovoH57EPMJ6cc5LID7gHfp38FNgNT4dmwyP4PjQ72QHPh2bDY2iTKedA+/zppAiHTCIXoX3+EzBmyCTC544fQzmGPg5A2+8atCiJDI0C6EQBdLLoAN6HB41v4KJ4Ce3fYxLpg0nG9mMiyyKZFKF2It0sJIlwf3jFOLVfrICd0I5zL3STRBTO+grkQOxz2OLA/yj1CuSY4v6UY58FLWOGRgF0ogA6GSKAt+ExY8mCbC4svtpxct/vJpkUoZYx3cydRFhV4aY8dhusjV3QjpO/64P/CNuPlZ0skojCtlcgKxP2caxgDMGQr0BVY9YaCqATBdBJbgDvwJPGj7A2WI2x4+TypQ9WY2y/nCrOhGRShFrGdKMkMjQKoJO2y5q8nHchNIvABfkLOOtlzZ/wCIwvay6amzC5rNkWQMJrriXZAjeF5oScABIG8XdoFmHzqgnJpFiJOUmkCjUHOlEAnXAObHu7LJu38EZoNlyGh0JTCCFEDdSaRJ7DW6HZwIvg+0OzLloXiEtWC+mxoAA6aSsm8M6fknf/sIjAYkJMTjGBRQQWE0oydeqsLYC8Wn8pNIvAqjLLWXEQc0/ps5z1bfJTGTiGqZNnyaQIVdLvRiX9oVEAneQGkOdEeGwidqoy2wKP1dp+NR7/dZG8p2HbHDjv2RieS7H9GMQYzYFjRgF0ogA6yQ0gz4lwcR37BfbxBNp+n+C6IpkUoRbS3Yw6iXD5xG1YLJdZLsYUQN7W9dQ4dff5rCiJOFEAnSiATsYUQN49ddWYc/y3lyQtQy1jupl7GcN0z+JBbE41hp/HYvvZ8v2aJjeALKW/Mubc7X0K2n6H4bpBScSJAuhEAXSSG0Cm++vGnGrMa2j7qRozMKrGjBkF0IkC6KTtbEzpj0HmjobFzXhnk3M2Zhkfg8zNw1QRNpkUKzEniVSh3sJOFEAnCqCLlZW/aEC68YlcxMUAAAAASUVORK5CYII="),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class DataGenerator : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new DataGeneratorControl();
        }

    }
}