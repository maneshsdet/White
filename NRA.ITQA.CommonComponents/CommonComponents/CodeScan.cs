//using IronBarCode;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CommonComponents
//{
//    public static class CodeScan
//    {

//        public static string ReadQRCode(string ScanLicense, string pdffile)
//        {
//            try
//            {
//                License.LicenseKey = ScanLicense;
//                //  bool result = License.IsValidLicense("IRONBARCODE-MYLICENSE-KEY-1EF01");
//                //bool is_licensed = License.IsLicensed;
//                var PDFResults = BarcodeReader.ReadPdf(pdffile);
//                try
//                {
//                    foreach (var PageResult in PDFResults)
//                    {
//                        string Value = PageResult.Value;
//                        // int PageNum = PageResult.PageNumber;
//                        //System.Drawing.Bitmap Img = PageResult.BarcodeImage;
//                        //BarcodeEncoding BarcodeType = PageResult.BarcodeType;
//                        //byte[] Binary = PageResult.BinaryValue;
//                        // Console.WriteLine(PageResult.Value + " on page " + PageNum);
//                        if (!string.IsNullOrEmpty(PageResult.Value))
//                        {
//                            return PageResult.Value;
//                        }
//                    }
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//            }
//            catch (Exception e1)
//            {
//                Console.WriteLine(e1.Message);
//            }
//            return null;
//        }
//    }
//}
