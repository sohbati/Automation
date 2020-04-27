using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Andicator.scan
{
    class Scanner
    {
        string DeviceID;

        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatPNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatGIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

       public ArrayList ADFScan()
        {
            ArrayList dataArray = new ArrayList();
           
            //Choose Scanner
            CommonDialogClass class1 = new CommonDialogClass();
           //
           
            //class1.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false, false);
           //
            Device d = class1.ShowSelectDevice(WiaDeviceType.UnspecifiedDeviceType, true, false);
            if (d != null)
            {
                this.DeviceID = d.DeviceID;
            }
            else
            {
                //no scanner chosen
                return new ArrayList();
            }



            WIA.CommonDialog WiaCommonDialog = new CommonDialogClass();

            bool hasMorePages = true;
            int x = 0;
            int numPages = 0;
            while (hasMorePages)
            {
                //Create DeviceManager
                DeviceManager manager = new DeviceManagerClass();
                Device WiaDev = null;
                foreach (DeviceInfo info in manager.DeviceInfos)
                {
                    if (info.DeviceID == this.DeviceID)
                    {
                        WIA.Properties infoprop = null;
                        infoprop = info.Properties;

                        //connect to scanner
                        WiaDev = info.Connect();


                        break;
                    }
                }

                

                //Start Scan

                WIA.ImageFile img = null;
                WIA.Item Item = WiaDev.Items[1] as WIA.Item;

                try
                {

                    img = (ImageFile)WiaCommonDialog.ShowTransfer(Item, wiaFormatJPEG, false);

                     
                    //process image:
                    //one would do image processing here
                    //
                    dataArray.Add(img);
                    //Save to file
                    //string varImageFileName = "c:\\test" + x.ToString() + ".jpg";
                   // if (File.Exists(varImageFileName))
                   // {
                   //     //file exists, delete it
                   //     File.Delete(varImageFileName);
                   // }
                   // img.SaveFile(varImageFileName);
                    numPages++;
                    img = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Item = null;
                    //determine if there are any more pages waiting
                    Property documentHandlingSelect = null;
                    Property documentHandlingStatus = null;
                    foreach (Property prop in WiaDev.Properties)
                    {
                        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
                            documentHandlingSelect = prop;
                        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
                            documentHandlingStatus = prop;


                    }

                    hasMorePages = false; //assume there are no more pages
                    if (documentHandlingSelect != null)
                    //may not exist on flatbed scanner but required for feeder
                    {
                        //check for document feeder
                        if ((Convert.ToUInt32(documentHandlingSelect.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER) != 0)
                        {
                            hasMorePages = ((Convert.ToUInt32(documentHandlingStatus.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY) != 0);
                        }
                    }
                    x++;
                }
            }
            return dataArray;
        }
      
    }

    class WIA_DPS_DOCUMENT_HANDLING_SELECT
	{
		public const uint FEEDER = 0x00000001;
		public const uint FLATBED = 0x00000002;
	}

	class WIA_DPS_DOCUMENT_HANDLING_STATUS
	{
		public const uint FEED_READY = 0x00000001;
	}

	class WIA_PROPERTIES
	{
		public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
		public const uint WIA_DIP_FIRST = 2;
		public const uint WIA_DPA_FIRST  =  WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
		public const uint WIA_DPC_FIRST  = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
		//
		// Scanner only device properties (DPS)
		//
		public const uint WIA_DPS_FIRST    =                      WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
		public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS  =     WIA_DPS_FIRST + 13;
		public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT  =     WIA_DPS_FIRST + 14;
	}

	class WIA_ERRORS
	{
		public const uint BASE_VAL_WIA_ERROR = 0x80210000;
		public const uint WIA_ERROR_PAPER_EMPTY  = BASE_VAL_WIA_ERROR + 3;
	}
}
