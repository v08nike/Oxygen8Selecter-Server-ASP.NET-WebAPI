using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dpoint.dpointSelection;


namespace Oxygen8SelectorServer.Models
{
    public class ClsHeatExchCORE_DLL
    {
        //List<string> _metric = new List<string>(new string[] { "C", "m", "mm", "m/s", "m3/hr", "J", "Pa" });
        //List<string> _imperial = new List<string>(new string[] { "F", "ft", "in", "ft/s", "scfm", "BTU", "in w.c" });

        //private const string OutputFormatMetric = "n1";
        //private const string OutputFormatImperial = "n1";

        //private const int LargeLength = 1;
        //private const int SmallLength = 2;
        //private const int Temperature = 0;
        //private const int Velocity = 3;
        //private const int Volume = 4;
        //private const int Energy = 5;
        //private const int Pressure = 6;

        //private bool _update = false;
        //private IPressure pressure;
        //private IDistanceLarge elevation;
        //private IDistanceSmall spacing;
        //private IDistanceSmall height;
        //private IDistanceSmall size;
        //private IPressure maxPressureDrop;
        //double minEffectiveness;
        // bool bolUserElevation = false;
        // string strProductModel = "";


        //public ClsHeatExchCORE_DLL()
        //{
        //}




        public static ClsCORE_DLL_IO CalcPerf(ClsCORE_DLL_IO _objIOSummer, ClsCORE_DLL_IO _objIOWinter)
        {

            List<string> _metric = new List<string>(new string[] { "C", "m", "mm", "m/s", "m3/hr", "J", "Pa" });
            List<string> _imperial = new List<string>(new string[] { "F", "ft", "in", "ft/s", "scfm", "BTU", "in w.c" });

            const string OutputFormatMetric = "n1";
            const string OutputFormatImperial = "n1";

            const int LargeLength = 1;
            const int SmallLength = 2;
            const int Temperature = 0;
            const int Velocity = 3;
            const int Volume = 4;
            const int Energy = 5;
            const int Pressure = 6;

            //try
            //{
            //    dpointProducts.ReadConfigurationFile();
            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show("The default configuration file could not be found.");
            //    //Close();
            //}

            ////dpointProducts.ReadConfigurationFile("C:\\CORE_DLL_PRODUCTS\\Product Selection Configuration.xml");
            //dpointProducts.ReadConfigurationFile(HttpContext.Current.Server.MapPath("/CoreDLL_XML/Product Selection Configuration.xml"));
            dpointProducts.ReadConfigurationFile(HttpContext.Current.Server.MapPath("/CoreDLL_XML/Product Selection Configuration.xml"));


            bool _update = false;
            IPressure pressure;
            IDistanceLarge elevation;
            //IDistanceSmall spacing;
            IDistanceSmall supply_pitch;
            IDistanceSmall exhaust_pitch;

            IDistanceSmall height;
            IDistanceSmall size;
            dpointProducts.FrameDescription frame;
            dpointProducts.FrameDescription frame1;

            IPressure maxPressureDrop;
            double minEffectiveness;
            bool bolUserElevation = false;
            string strProductModel = "";



            bolUserElevation = true;


            //List<string> products = dpointProducts.ProductList;

            //string product = "A16 (62x40x16)";
            //product = products[0].ToString();

            dpInputConditions SummerOutsideAir = new dpInputConditions();
            dpInputConditions SummerReturnAir = new dpInputConditions();
            dpInputConditions WinterOutsideAir = new dpInputConditions();
            dpInputConditions WinterReturnAir = new dpInputConditions();



            //strProductModel = product;
            strProductModel = _objIOSummer.strInProductModel;

            if (_objIOSummer.intUoM == ClsID.intUoM_Imperial)
            {
                SummerOutsideAir.AirFlowRate = new Scfm(_objIOSummer.dblInOutsideAirCFM);
                SummerOutsideAir.DryBulbTemperature = new Fahrenheit(_objIOSummer.dblInOutsideAirDB);
                SummerOutsideAir.WetBulbTemperature = new Fahrenheit(_objIOSummer.dblInOutsideAirDB == _objIOSummer.dblInOutsideAirWB ? _objIOSummer.dblInOutsideAirWB - 0.1d : _objIOSummer.dblInOutsideAirWB);
                SummerOutsideAir.RelativeHumidity = _objIOSummer.dblInOutsideAirRH;
                SummerReturnAir.AirFlowRate = new Scfm(_objIOSummer.dblInReturnAirCFM);
                SummerReturnAir.DryBulbTemperature = new Fahrenheit(_objIOSummer.dblInReturnAirDB);
                SummerReturnAir.WetBulbTemperature = new Fahrenheit(_objIOSummer.dblInReturnAirDB == _objIOSummer.dblInReturnAirWB ? _objIOSummer.dblInReturnAirWB - 0.1d : _objIOSummer.dblInReturnAirWB);
                SummerReturnAir.RelativeHumidity = _objIOSummer.dblInReturnAirRH;

                WinterOutsideAir.AirFlowRate = new Scfm(_objIOWinter.dblInOutsideAirCFM);
                WinterOutsideAir.DryBulbTemperature = new Fahrenheit(_objIOWinter.dblInOutsideAirDB);
                WinterOutsideAir.WetBulbTemperature = new Fahrenheit(_objIOWinter.dblInOutsideAirDB == _objIOWinter.dblInOutsideAirWB ? _objIOWinter.dblInOutsideAirWB - 0.1d : _objIOWinter.dblInOutsideAirWB);
                WinterOutsideAir.RelativeHumidity = _objIOWinter.dblInOutsideAirRH;
                WinterReturnAir.AirFlowRate = new Scfm(_objIOWinter.dblInReturnAirCFM);
                WinterReturnAir.DryBulbTemperature = new Fahrenheit(_objIOWinter.dblInReturnAirDB);
                WinterReturnAir.WetBulbTemperature = new Fahrenheit(_objIOWinter.dblInReturnAirDB == _objIOWinter.dblInReturnAirWB ? _objIOWinter.dblInReturnAirWB - 0.1d : _objIOWinter.dblInReturnAirWB);
                WinterReturnAir.RelativeHumidity = _objIOWinter.dblInReturnAirRH;

                //size = new Inches(_objIO.dblInFramedWidth);             //Frame Width
                //height = new Inches(_objIO.dblInHeight);           //Height       
                //spacing = new Inches(_objIO.dblInSpacing);         //Spacing
                //size = new Inches((double)39.37);             //Frame Width
                //height = new Inches((double)0);           //Height       
                //spacing = new Inches((double)0.130);         //Spacing
                //size = new Inches(39.37d);             //Frame Width
                //height = new Inches(22.52d);           //Height       
                //spacing = new Inches(0.130d);         //Spacing
                size = new Millimeters(_objIOSummer.dblInFramedWidth);      //Frame Width
                height = new Millimeters(_objIOSummer.dblInHeight);         //Height       
                supply_pitch = new Millimeters(_objIOSummer.dblInSupplyPitch);       //Spacing
                exhaust_pitch = new Millimeters(_objIOSummer.dblInExhaustPitch);       //Spacing




                dpointProducts.dpointProduct product = dpointProducts.ProductProperties(strProductModel, size);

                frame1 = product.Frame[0];

                minEffectiveness = 0d / 100d;
                maxPressureDrop = new Wc(1000d);
                elevation = new Feet(_objIOSummer.dblInAltitude);                 //Elevation
                pressure = new Millibar(0d);                //Pressure

                //outsideAir.AirFlowRate = new M3hr(Math.Round(_objIO.dblInOutsideAirCFM * ClsFormula.dblCFM_To_CMH, 0));
                //outsideAir.DryBulbTemperature = new Celsius(Math.Round(ClsFormula.get_dblCelcius(_objIO.dblInOutsideAirDB), 1));
                //outsideAir.WetBulbTemperature = new Celsius(Math.Round(ClsFormula.get_dblCelcius(_objIO.dblInOutsideAirDB == _objIO.dblInOutsideAirWB ? _objIO.dblInOutsideAirWB - 0.001d : _objIO.dblInOutsideAirWB), 1));
                //returnAir.AirFlowRate = new M3hr(Math.Round(_objIO.dblInReturnAirCFM * ClsFormula.dblCFM_To_CMH, 0));
                //returnAir.DryBulbTemperature = new Celsius(Math.Round(ClsFormula.get_dblCelcius(_objIO.dblInReturnAirDB), 1));
                //returnAir.WetBulbTemperature = new Celsius(Math.Round(ClsFormula.get_dblCelcius(_objIO.dblInReturnAirDB == _objIO.dblInReturnAirWB ? _objIO.dblInReturnAirWB - 0.001d : _objIO.dblInReturnAirWB), 1));
                //size = new Millimeters(_objIO.dblInFramedWidth);    //Frame Width
                //height = new Millimeters(_objIO.dblInHeight);       //Height       
                //spacing = new Millimeters(_objIO.dblInSpacing);     //Spacing
                //minEffectiveness = 0d / 100d;
                //maxPressureDrop = new Kilopascal(1000d);
                //elevation = new Meters(_objIO.dblInAltitude);       //Elevation
                //pressure = new Millibar(0d);                        //Pressure
            }
            else
            {
                SummerOutsideAir.AirFlowRate = new M3hr(_objIOSummer.dblInOutsideAirCFM);
                SummerOutsideAir.DryBulbTemperature = new Celsius(_objIOSummer.dblInOutsideAirDB);
                SummerOutsideAir.WetBulbTemperature = new Celsius(_objIOSummer.dblInOutsideAirDB == _objIOSummer.dblInOutsideAirWB ? _objIOSummer.dblInOutsideAirWB - 0.1d : _objIOSummer.dblInOutsideAirWB);
                SummerOutsideAir.RelativeHumidity = _objIOSummer.dblInOutsideAirRH;
                SummerReturnAir.AirFlowRate = new M3hr(_objIOSummer.dblInReturnAirCFM);
                SummerReturnAir.DryBulbTemperature = new Celsius(_objIOSummer.dblInReturnAirDB);
                SummerReturnAir.WetBulbTemperature = new Celsius(_objIOSummer.dblInReturnAirDB == _objIOSummer.dblInReturnAirWB ? _objIOSummer.dblInReturnAirWB - 0.1d : _objIOSummer.dblInReturnAirWB);
                SummerReturnAir.RelativeHumidity = _objIOSummer.dblInReturnAirRH;

                WinterOutsideAir.AirFlowRate = new M3hr(_objIOWinter.dblInOutsideAirCFM);
                WinterOutsideAir.DryBulbTemperature = new Celsius(_objIOWinter.dblInOutsideAirDB);
                WinterOutsideAir.WetBulbTemperature = new Celsius(_objIOWinter.dblInOutsideAirDB == _objIOWinter.dblInOutsideAirWB ? _objIOWinter.dblInOutsideAirWB - 0.1d : _objIOWinter.dblInOutsideAirWB);
                WinterOutsideAir.RelativeHumidity = _objIOWinter.dblInOutsideAirRH;
                WinterReturnAir.AirFlowRate = new M3hr(_objIOWinter.dblInReturnAirCFM);
                WinterReturnAir.DryBulbTemperature = new Celsius(_objIOWinter.dblInReturnAirDB);
                WinterReturnAir.WetBulbTemperature = new Celsius(_objIOWinter.dblInReturnAirDB == _objIOWinter.dblInReturnAirWB ? _objIOWinter.dblInReturnAirWB - 0.1d : _objIOWinter.dblInReturnAirWB);
                WinterReturnAir.RelativeHumidity = _objIOWinter.dblInReturnAirRH;


                size = new Millimeters(_objIOSummer.dblInFramedWidth);      //Frame Width
                height = new Millimeters(_objIOSummer.dblInHeight);         //Height       
                supply_pitch = new Millimeters(_objIOSummer.dblInSupplyPitch);       //Spacing
                exhaust_pitch = new Millimeters(_objIOSummer.dblInExhaustPitch);       //Spacing



                dpointProducts.dpointProduct product = dpointProducts.ProductProperties(strProductModel, size);
                frame1 = product.Frame[0];

                minEffectiveness = 0d / 100d;
                maxPressureDrop = new Kilopascal(1000d);
                elevation = new Meters(_objIOSummer.dblInAltitude);         //Elevation
                pressure = new Millibar(0d);                        //Pressure
            }

            //    Call the calculator using the variables set up above
            dpointSelectionCalculator calculator = new dpointSelectionCalculator();


            if (bolUserElevation)
            {
                calculator = new dpointSelectionCalculator(strProductModel, height, size, frame1, supply_pitch, exhaust_pitch, elevation);

            }
            else
            {
                calculator = new dpointSelectionCalculator(strProductModel, height, size, frame1, supply_pitch, exhaust_pitch, pressure);
            }



            ////    Catch and display any exceptions thrown by the core calculator
            ////    The calculator will generate exceptions in a number of circumstances that are documented in the developer's guide
            //try
            //{
            dpSelectionCalculatorResults results = calculator.Calculate(SummerOutsideAir, SummerReturnAir, WinterOutsideAir, WinterReturnAir);

            _objIOSummer.strAHRICertificationMessage = results.AhriCertificationMessage;
            _objIOSummer.bolAHRICertified = results.AhriCertificationMessage.Contains("Certified");


            if (_objIOSummer.intUoM == ClsID.intUoM_Imperial)
            {
                _objIOSummer.dblOutSupplyAirCFM = SummerOutsideAir.AirFlowRate.ToImperial();
                _objIOSummer.dblOutSupplyAirDB = results.SummerSupplyAir.DryBulbTemperature.ToImperial();
                _objIOSummer.dblOutSupplyAirWB = results.SummerSupplyAir.WetBulbTemperature.ToImperial();
                _objIOSummer.dblOutSupplyAirRH = results.SummerSupplyAir.RelativeHumidity;
                _objIOSummer.bolOutSupplyAirCondWarning = results.SummerSupplyAir.CondensationWarning;
                _objIOSummer.dblOutSupplyAirPD = results.SummerCorePerformance.PressureDropSupplyStream.ToImperial();
                _objIOSummer.dblOutSupplyAirVel = results.SummerCorePerformance.FaceVelocitySupplyStream.ToImperial();

                _objIOSummer.dblOutExhaustAirCFM = SummerReturnAir.AirFlowRate.ToImperial();
                _objIOSummer.dblOutExhaustAirDB = results.SummerExhaustAir.DryBulbTemperature.ToImperial();
                _objIOSummer.dblOutExhaustAirWB = results.SummerExhaustAir.WetBulbTemperature.ToImperial();
                _objIOSummer.dblOutExhaustAirRH = results.SummerExhaustAir.RelativeHumidity;
                _objIOSummer.bolOutExhaustAirCondWar = results.SummerExhaustAir.CondensationWarning;
                _objIOSummer.dblOutExhaustAirPD = results.SummerCorePerformance.PressureDropExhaustStream.ToImperial();
                _objIOSummer.dblOutExhaustAirVel = results.SummerCorePerformance.FaceVelocityExhaustStream.ToImperial();

                _objIOSummer.dblOutSensibleEffectiveness = results.SummerCorePerformance.SensibleEffectiveness;
                _objIOSummer.dblOutLatentEffectiveness = results.SummerCorePerformance.LatentEffectiveness;
                _objIOSummer.dblOutTotalEffectiveness = results.SummerCorePerformance.TotalEffectiveness;
                //_objIO.bolOutConditionsMarginal = results.SummerCorePerformance.TotalEffectivenessReasonable;
                _objIOSummer.dblOutTotalEnergySaved = results.SummerCorePerformance.TotalEnergySaved.ToImperial();
                _objIOSummer.dblOutTemperatureRatio = results.SummerCorePerformance.TemperatureRatio;
                _objIOSummer.dblOutWaterTransferRatio = results.SummerCorePerformance.WaterTransferRatio;
                _objIOSummer.dblOutMoistureTransfered = results.SummerCorePerformance.MoistureTransfered.ToImperial();
                _objIOSummer.dblOutPrice = results.Price;

                _objIOWinter.dblOutSupplyAirCFM = WinterOutsideAir.AirFlowRate.ToImperial();
                _objIOWinter.dblOutSupplyAirDB = results.WinterSupplyAir.DryBulbTemperature.ToImperial();
                _objIOWinter.dblOutSupplyAirWB = results.WinterSupplyAir.WetBulbTemperature.ToImperial();
                _objIOWinter.dblOutSupplyAirRH = results.WinterSupplyAir.RelativeHumidity;
                _objIOWinter.bolOutSupplyAirCondWarning = results.WinterSupplyAir.CondensationWarning;
                _objIOWinter.dblOutSupplyAirPD = results.WinterCorePerformance.PressureDropSupplyStream.ToImperial();
                _objIOWinter.dblOutSupplyAirVel = results.WinterCorePerformance.FaceVelocitySupplyStream.ToImperial();

                _objIOWinter.dblOutExhaustAirCFM = WinterReturnAir.AirFlowRate.ToImperial();
                _objIOWinter.dblOutExhaustAirDB = results.WinterExhaustAir.DryBulbTemperature.ToImperial();
                _objIOWinter.dblOutExhaustAirWB = results.WinterExhaustAir.WetBulbTemperature.ToImperial();
                _objIOWinter.dblOutExhaustAirRH = results.WinterExhaustAir.RelativeHumidity;
                _objIOWinter.bolOutExhaustAirCondWar = results.WinterExhaustAir.CondensationWarning;
                _objIOWinter.dblOutExhaustAirPD = results.WinterCorePerformance.PressureDropExhaustStream.ToImperial();
                _objIOWinter.dblOutExhaustAirVel = results.WinterCorePerformance.FaceVelocityExhaustStream.ToImperial();

                _objIOWinter.dblOutSensibleEffectiveness = results.WinterCorePerformance.SensibleEffectiveness;
                _objIOWinter.dblOutLatentEffectiveness = results.WinterCorePerformance.LatentEffectiveness;
                _objIOWinter.dblOutTotalEffectiveness = results.WinterCorePerformance.TotalEffectiveness;
                //_objIO.bolOutConditionsMarginal = results.WinterCorePerformance.TotalEffectivenessReasonable;
                _objIOWinter.dblOutTotalEnergySaved = results.WinterCorePerformance.TotalEnergySaved.ToImperial();
                _objIOWinter.dblOutTemperatureRatio = results.WinterCorePerformance.TemperatureRatio;
                _objIOWinter.dblOutWaterTransferRatio = results.WinterCorePerformance.WaterTransferRatio;
                _objIOWinter.dblOutMoistureTransfered = results.WinterCorePerformance.MoistureTransfered.ToImperial();
                _objIOWinter.dblOutPrice = results.Price;
            }
            else if (_objIOSummer.intUoM == ClsID.intUoM_Metric)
            {
                _objIOSummer.dblOutSupplyAirCFM = SummerOutsideAir.AirFlowRate.ToMetric();
                _objIOSummer.dblOutSupplyAirDB = results.SummerSupplyAir.DryBulbTemperature.ToMetric();
                _objIOSummer.dblOutSupplyAirWB = results.SummerSupplyAir.WetBulbTemperature.ToMetric();
                _objIOSummer.dblOutSupplyAirRH = results.SummerSupplyAir.RelativeHumidity;
                _objIOSummer.bolOutSupplyAirCondWarning = results.SummerSupplyAir.CondensationWarning;
                _objIOSummer.dblOutSupplyAirPD = results.SummerSupplyAir.DryBulbTemperature.ToMetric();
                _objIOSummer.dblOutSupplyAirVel = results.SummerSupplyAir.DryBulbTemperature.ToMetric();

                _objIOSummer.dblOutExhaustAirCFM = SummerReturnAir.AirFlowRate.ToMetric();
                _objIOSummer.dblOutExhaustAirDB = results.SummerExhaustAir.DryBulbTemperature.ToMetric();
                _objIOSummer.dblOutExhaustAirWB = results.SummerExhaustAir.WetBulbTemperature.ToMetric();
                _objIOSummer.dblOutExhaustAirRH = results.SummerExhaustAir.RelativeHumidity;
                _objIOSummer.bolOutExhaustAirCondWar = results.SummerExhaustAir.CondensationWarning;
                _objIOSummer.dblOutExhaustAirPD = results.SummerExhaustAir.DryBulbTemperature.ToMetric();
                _objIOSummer.dblOutExhaustAirVel = results.SummerExhaustAir.DryBulbTemperature.ToMetric();

                _objIOSummer.dblOutSensibleEffectiveness = results.SummerCorePerformance.SensibleEffectiveness;
                _objIOSummer.dblOutLatentEffectiveness = results.SummerCorePerformance.LatentEffectiveness;
                _objIOSummer.dblOutTotalEffectiveness = results.SummerCorePerformance.TotalEffectiveness;
                _objIOSummer.dblOutTotalEnergySaved = results.SummerCorePerformance.TotalEnergySaved.ToImperial();
                _objIOSummer.dblOutTemperatureRatio = results.SummerCorePerformance.TemperatureRatio;
                //_objIO.bolOutConditionsMarginal = results.SummerCorePerformance.TotalEffectivenessReasonable;
                _objIOSummer.dblOutWaterTransferRatio = results.SummerCorePerformance.WaterTransferRatio;
                _objIOSummer.dblOutMoistureTransfered = results.SummerCorePerformance.MoistureTransfered.ToMetric();
                _objIOSummer.dblOutPrice = results.Price;

                _objIOWinter.dblOutSupplyAirCFM = WinterOutsideAir.AirFlowRate.ToMetric();
                _objIOWinter.dblOutSupplyAirDB = results.WinterSupplyAir.DryBulbTemperature.ToMetric();
                _objIOWinter.dblOutSupplyAirWB = results.WinterSupplyAir.WetBulbTemperature.ToMetric();
                _objIOWinter.dblOutSupplyAirRH = results.WinterSupplyAir.RelativeHumidity;
                _objIOWinter.bolOutSupplyAirCondWarning = results.WinterSupplyAir.CondensationWarning;
                _objIOWinter.dblOutSupplyAirPD = results.WinterSupplyAir.DryBulbTemperature.ToMetric();
                _objIOWinter.dblOutSupplyAirVel = results.WinterSupplyAir.DryBulbTemperature.ToMetric();

                _objIOWinter.dblOutExhaustAirCFM = WinterReturnAir.AirFlowRate.ToMetric();
                _objIOWinter.dblOutExhaustAirDB = results.WinterExhaustAir.DryBulbTemperature.ToMetric();
                _objIOWinter.dblOutExhaustAirWB = results.WinterExhaustAir.WetBulbTemperature.ToMetric();
                _objIOWinter.dblOutExhaustAirRH = results.WinterExhaustAir.RelativeHumidity;
                _objIOWinter.bolOutExhaustAirCondWar = results.WinterExhaustAir.CondensationWarning;
                _objIOWinter.dblOutExhaustAirPD = results.WinterExhaustAir.DryBulbTemperature.ToMetric();
                _objIOWinter.dblOutExhaustAirVel = results.WinterExhaustAir.DryBulbTemperature.ToMetric();

                _objIOWinter.dblOutSensibleEffectiveness = results.WinterCorePerformance.SensibleEffectiveness;
                _objIOWinter.dblOutLatentEffectiveness = results.WinterCorePerformance.LatentEffectiveness;
                _objIOWinter.dblOutTotalEffectiveness = results.WinterCorePerformance.TotalEffectiveness;
                _objIOWinter.dblOutTotalEnergySaved = results.WinterCorePerformance.TotalEnergySaved.ToImperial();
                _objIOWinter.dblOutTemperatureRatio = results.WinterCorePerformance.TemperatureRatio;
                //_objIO.bolOutConditionsMarginal = results.WinterCorePerformance.TotalEffectivenessReasonable;
                _objIOWinter.dblOutWaterTransferRatio = results.WinterCorePerformance.WaterTransferRatio;
                _objIOWinter.dblOutMoistureTransfered = results.WinterCorePerformance.MoistureTransfered.ToMetric();
                _objIOWinter.dblOutPrice = results.Price;


            }


            ////    If the call to the Calculate method of the calculator did not result in an exception,
            ////    then the calculation completed successfully
            ////    Display the results from the calculation in the user interface

            //}

            //catch (NegativeRelativeHumidityException)
            //{
            //    //MessageBox.Show("Current Design Conditions result in one or more relative humidity figures less than zero");
            //}
            //catch (HighRelativeHumidityException)
            //{
            //    //MessageBox.Show("Current Design Conditions result in one or more relative humidity figures greater than 100");
            //}
            //catch (HighFlowRateException)
            //{
            //    //MessageBox.Show("Flow rate entered is higher than recommended for selected core geometry.  Please adjust flow rates or core specifications.");
            //}
            //catch (LowFlowRateException)
            //{
            //    //MessageBox.Show("Flow rate entered is lower than recommended for selected core geometry.  Please adjust flow rates or core specifications.");
            //}
            //catch (InvalidOutputException)
            //{
            //    //MessageBox.Show("Core performance could not be calculated for selected inputs.");
            //}
            //catch (UnbalancedFlowException ubfe)
            //{
            //    //MessageBox.Show(ubfe.Message);
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //}

            return _objIOSummer;
        }


        //public void CalcPerfMetric(ClsCORE_DLL_IO _obj)
        //{
        //    //objCORE_DLL_IO = _obj;
        //    bolUserElevation = true;
        //    List<string> products = dpointProducts.ProductList;

        //    //string product = "A16 (62x40x16)";
        //    //product = products[0].ToString();

        //    dpInputConditions outsideAir = new dpInputConditions();
        //    dpInputConditions returnAir = new dpInputConditions();


        //    strProductModel = _obj.strInProductModel;

        //    //Metric-------------------------------------------------------------------------------------------------------
        //    //Outdoor Air
        //    outsideAir.AirFlowRate = new M3hr(_obj.dblInOutsideAirCFM);
        //    outsideAir.DryBulbTemperature = new Celsius(_obj.dblInOutsideAirDB);
        //    outsideAir.WetBulbTemperature = new Celsius(_obj.dblInOutsideAirWB);
        //    //outsideAir.UseRelativeHumidity = true;
        //    //outsideAir.RelativeHumidity = (double)50 / 100;

        //    //  Return Air
        //    returnAir.AirFlowRate = new M3hr(_obj.dblInReturnAirCFM);
        //    returnAir.DryBulbTemperature = new Celsius(_obj.dblInReturnAirDB);
        //    returnAir.WetBulbTemperature = new Celsius(_obj.dblInReturnAirWB);
        //    //returnAir.UseRelativeHumidity = true;
        //    //returnAir.RelativeHumidity = (double)50 / 100;

        //    size = new Millimeters(_obj.dblInFramedWidth);             //Frame Width
        //    height = new Millimeters(_obj.dblInHeight);           //Height       
        //    spacing = new Millimeters(_obj.dblInSpacing);         //Spacing
        //    minEffectiveness = 0d / 100d;
        //    maxPressureDrop = new Kilopascal(1000d);
        //    elevation = new Meters(_obj.dblInAltitude);                 //Elevation
        //    pressure = new Millibar(0d);                //Pressure


        //    //    Call the calculator using the variables set up above
        //    dpointSelectionCalculator calculator;


        //    if (bolUserElevation)
        //    {
        //        calculator = new dpointSelectionCalculator(strProductModel, height, size, spacing, elevation);
        //    }
        //    else
        //    {
        //        calculator = new dpointSelectionCalculator(strProductModel, height, size, spacing, pressure);
        //    }

        //    //    Catch and display any exceptions thrown by the core calculator
        //    //    The calculator will generate exceptions in a number of circumstances that are documented in the developer's guide
        //    try
        //    {
        //        dpSelectionCalculatorResults results = calculator.Calculate(outsideAir, returnAir);

        //        double dblSupplyAirDB = results.SupplyAir.DryBulbTemperature.ToMetric();
        //        double dblSupplyAirDB_Imp = results.SupplyAir.DryBulbTemperature.ToImperial();

        //        _obj.dblOutSupplyAirCFM = results.SupplyAir.EnergyFlowRate.ToImperial();
        //        _obj.dblOutSupplyAirDB = results.SupplyAir.DryBulbTemperature.ToImperial();
        //        _obj.dblOutSupplyAirWB = results.SupplyAir.WetBulbTemperature.ToImperial();
        //        _obj.bolOutSupplyAirCondWarning = results.SupplyAir.CondensationWarning;
        //        _obj.dblOutSupplyAirPD = results.SupplyAir.DryBulbTemperature.ToImperial();
        //        _obj.dblOutSupplyAirVel = results.SupplyAir.DryBulbTemperature.ToImperial();

        //        _obj.dblOutExhaustAirCFM = results.ExhaustAir.EnergyFlowRate.ToImperial();
        //        _obj.dblOutExhaustAirDB = results.ExhaustAir.DryBulbTemperature.ToImperial();
        //        _obj.dblOutExhaustAirWB = results.ExhaustAir.WetBulbTemperature.ToImperial();
        //        _obj.bolOutExhaustAirCondWar = results.ExhaustAir.CondensationWarning;
        //        _obj.dblOutExhaustAirPD = results.ExhaustAir.DryBulbTemperature.ToImperial();
        //        _obj.dblOutExhaustAirVel = results.ExhaustAir.DryBulbTemperature.ToImperial();

        //        _obj.dblOutSensibleEffectiveness = results.CorePerformance.SensibleEffectiveness;
        //        _obj.dblOutLatentEffectiveness = results.CorePerformance.LatentEffectiveness;
        //        _obj.dblOutTotalEffectiveness = results.CorePerformance.TotalEffectiveness;
        //        _obj.dblOutEnergySaving = results.CorePerformance.TotalEnergySaved.ToImperial();
        //        _obj.dblOutTemperatureRatio = results.CorePerformance.TemperatureRatio;
        //        _obj.bolOutConditionsMarginal = results.CorePerformance.TotalEffectivenessReasonable;
        //        _obj.dblOutWaterTransferRatio = results.CorePerformance.WaterTransferRatio;
        //        _obj.dblOutPrice = results.Price;


        //        //    If the call to the Calculate method of the calculator did not result in an exception,
        //        //    then the calculation completed successfully
        //        //    Display the results from the calculation in the user interface

        //        //UpdateOutput(results);
        //    }

        //    catch (NegativeRelativeHumidityException)
        //    {
        //        //MessageBox.Show("Current Design Conditions result in one or more relative humidity figures less than zero");
        //    }
        //    catch (HighRelativeHumidityException)
        //    {
        //        //MessageBox.Show("Current Design Conditions result in one or more relative humidity figures greater than 100");
        //    }
        //    catch (HighFlowRateException)
        //    {
        //        //MessageBox.Show("Flow rate entered is higher than recommended for selected core geometry.  Please adjust flow rates or core specifications.");
        //    }
        //    catch (LowFlowRateException)
        //    {
        //        //MessageBox.Show("Flow rate entered is lower than recommended for selected core geometry.  Please adjust flow rates or core specifications.");
        //    }
        //    catch (InvalidOutputException)
        //    {
        //        //MessageBox.Show("Core performance could not be calculated for selected inputs.");
        //    }
        //    catch (UnbalancedFlowException ubfe)
        //    {
        //        //MessageBox.Show(ubfe.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //}


        //public void CalcPerfImperial(ClsCORE_DLL_IO _obj)
        //{       
        //    bolUserElevation = true;
        //    List<string> products = dpointProducts.ProductList;
        //    //string product = "A16 (62x40x16)";
        //    //product = products[1].ToString();

        //    dpInputConditions outsideAir = new dpInputConditions();
        //    dpInputConditions returnAir = new dpInputConditions();

        //    #region Sample
        //    ////Outdoor Air
        //    //strProductModel = "A16 (62x40x16)";
        //    //outsideAir.AirFlowRate = new Scfm(500d);
        //    //outsideAir.DryBulbTemperature = new Fahrenheit(68.0d);
        //    //outsideAir.WetBulbTemperature = new Fahrenheit(50.0d);
        //    ////outsideAir.UseRelativeHumidity = true;
        //    ////outsideAir.RelativeHumidity = (double)50 / 100;
        //    //outsideAir.AFlow = outsideAir.AirFlowRate.ToMetric();

        //    ////  Return Air
        //    //returnAir.AirFlowRate = new Scfm(500d);
        //    //returnAir.DryBulbTemperature = new Fahrenheit(59.0d);
        //    //returnAir.WetBulbTemperature = new Fahrenheit(44.6d);
        //    ////returnAir.UseRelativeHumidity = true;
        //    ////returnAir.RelativeHumidity = (double)50 / 100;
        //    //returnAir.AFlow = returnAir.AirFlowRate.ToMetric();

        //    //size = new Inches(23.62204724409449d);                  //Frame Width
        //    //height = new Inches(13.77952755905512d);                //Height       
        //    //spacing = new Inches(0.094d);               //Spacing
        //    //minEffectiveness = 0d / 100d;
        //    //maxPressureDrop = new Wc(40.146d);
        //    //elevation = new Feet(1640d);                   //Elevation
        //    //pressure = new Millibar(0d);                //Pressure
        //    #endregion


        //    //  Outside Air
        //    strProductModel = _obj.strInProductModel;
        //    outsideAir.AirFlowRate = new Scfm(_obj.dblInOutsideAirCFM);
        //    outsideAir.DryBulbTemperature = new Fahrenheit(_obj.dblInOutsideAirDB);
        //    outsideAir.WetBulbTemperature = new Fahrenheit(_obj.dblInOutsideAirWB);
        //    //outsideAir.UseRelativeHumidity = true;
        //    //outsideAir.RelativeHumidity = (double)50 / 100;

        //    //  Return Air
        //    returnAir.AirFlowRate = new Scfm(_obj.dblInReturnAirCFM);
        //    returnAir.DryBulbTemperature = new Fahrenheit(_obj.dblInReturnAirDB);
        //    returnAir.WetBulbTemperature = new Fahrenheit(_obj.dblInReturnAirWB);
        //    //returnAir.UseRelativeHumidity = true;
        //    //returnAir.RelativeHumidity = (double)50 / 100;

        //    size = new Inches(_obj.dblInFramedWidth);                  //Frame Width
        //    height = new Inches(_obj.dblInHeight);                //Height       
        //    spacing = new Inches(_obj.dblInSpacing);               //Spacing
        //    minEffectiveness = 0d / 100d;
        //    maxPressureDrop = new Wc(40.146d);
        //    elevation = new Feet(_obj.dblInAltitude);                   //Elevation
        //    pressure = new Millibar(0d);                //Pressure


        //    //var dpp = dpointProducts.ProductProperties(product, spacing);

        //    CustomizedCalculator(strProductModel, outsideAir, returnAir, pressure, elevation, spacing, height, size);
        //    //StandardCalculator(outsideAir, returnAir, pressure, elevation, height, size, minEffectiveness, maxPressureDrop);
        //}


        //private void CustomizedCalculator(string product, dpInputConditions outsideAir, dpInputConditions returnAir, IPressure pressure, IDistanceLarge elevation, IDistanceSmall spacing, IDistanceSmall height, IDistanceSmall size)
        //{
        //    //    Call the calculator using the variables set up above
        //    dpointSelectionCalculator calculator;



        //    if (bolUserElevation)
        //    {
        //        calculator = new dpointSelectionCalculator(product, height, size, spacing, elevation);
        //    }
        //    else
        //    {
        //        calculator = new dpointSelectionCalculator(product, height, size, spacing, pressure);
        //    }

        //    calculator.PlateSize.ToMetric();

        //    //    Catch and display any exceptions thrown by the core calculator
        //    //    The calculator will generate exceptions in a number of circumstances that are documented in the developer's guide
        //    try
        //    {
        //        dpSelectionCalculatorResults results = calculator.Calculate(outsideAir, returnAir);
        //        //objCORE_DLL_IO.dblOutSupplyAirCFM = results.SupplyAir.EnergyFlowRate;
        //        //objCORE_DLL_IO.dblOutSupplyAirDB = results.SupplyAir.DryBulbTemperature;

        //        //    If the call to the Calculate method of the calculator did not result in an exception,
        //        //    then the calculation completed successfully
        //        //    Display the results from the calculation in the user interface

        //        //UpdateOutput(results);
        //    }
        //    catch (NegativeRelativeHumidityException)
        //    {
        //        //MessageBox.Show("Current Design Conditions result in one or more relative humidity figures less than zero");
        //    }
        //    catch (HighRelativeHumidityException)
        //    {
        //        //MessageBox.Show("Current Design Conditions result in one or more relative humidity figures greater than 100");
        //    }
        //    catch (HighFlowRateException)
        //    {
        //        //MessageBox.Show("Flow rate entered is higher than recommended for selected core geometry.  Please adjust flow rates or core specifications.");
        //    }
        //    catch (LowFlowRateException)
        //    {
        //        //MessageBox.Show("Flow rate entered is lower than recommended for selected core geometry.  Please adjust flow rates or core specifications.");
        //    }
        //    catch (InvalidOutputException)
        //    {
        //        //MessageBox.Show("Core performance could not be calculated for selected inputs.");
        //    }
        //    catch (UnbalancedFlowException ubfe)
        //    {
        //        //MessageBox.Show(ubfe.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //}



        //private void StandardCalculator(dpInputConditions outsideAir, dpInputConditions returnAir, IPressure pressure, IDistanceLarge elevation, IDistanceSmall height, IDistanceSmall size, double minEffectiveness, IPressure maxPressureDrop)
        //{
        //    //    For Standard mode call the calculator using the empty constructor.
        //    dpointSelectionCalculator calculator = new dpointSelectionCalculator();


        //    //    Catch and display any exceptions thrown by the core calculator
        //    //    The calculator will generate exceptions in a number of circumstances that are documented in the developer's guide
        //    try
        //    {
        //        //    Call the Serch function and the calculator will find the product which meet the search parameters
        //        //    and return the results in an array.
        //        dpSelectionCalculatorResults[] results;

        //        if (bolUserElevation)
        //        {
        //            results = calculator.Search(outsideAir, returnAir, height, size, elevation, minEffectiveness, maxPressureDrop);
        //        }
        //        else
        //        {
        //            results = calculator.Search(outsideAir, returnAir, height, size, pressure, minEffectiveness, maxPressureDrop);
        //        }


        //        if (results.Count() != 0)
        //        {
        //            //    If the call to the Calculate method of the calculator did not result in an exception,
        //            //    then the calculation completed successfully
        //            //    Display the results from the calculation in the user interface

        //            //UpdateOutput(results);
        //        }
        //        else
        //        {
        //            //MessageBox.Show("No products were found to meet the currently selected requirements.");

        //        }
        //    }
        //    catch (NegativeRelativeHumidityException)
        //    {
        //        //MessageBox.Show("Current Design Conditions result in one or more relative humidity figures less than zero");
        //    }
        //    catch (HighRelativeHumidityException)
        //    {
        //        //MessageBox.Show("Current Design Conditions result in one or more relative humidity figures greater than 100");
        //    }
        //    catch (HighFlowRateException)
        //    {
        //        //MessageBox.Show("Flow rate entered is higher than recommended for selected core geometry.  Please adjust flow rates or core specifications.");
        //    }
        //    catch (LowFlowRateException)
        //    {
        //        //MessageBox.Show("Flow rate entered is lower than recommended for selected core geometry.  Please adjust flow rates or core specifications.");
        //    }
        //    catch (InvalidOutputException)
        //    {
        //        //MessageBox.Show("Core performance could not be calculated for selected inputs.");
        //    }
        //    catch (UnbalancedFlowException ubfe)
        //    {
        //        //MessageBox.Show(ubfe.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //}

    }


    public class ClsCORE_DLL_IO
    {

        //Inputs
        public int intUoM { get; set; }
        public string strModel { get; set; }
        public string strInProductModel { get; set; }
        public double dblInFramedWidth { get; set; }            //Frame Width / Size
        public double dblInHeight { get; set; }                 //Height       
        public double dblInSupplyPitch { get; set; }                //Spacing
        public double dblInExhaustPitch { get; set; }
        public string strFrameType { get; set; }
        public double dblInAltitude { get; set; }
        public double dblInPressurePSI { get; set; }
        public double dblInOutsideAirCFM { get; set; }
        public double dblInOutsideAirDB { get; set; }
        public double dblInOutsideAirWB { get; set; }
        public double dblInOutsideAirRH { get; set; }
        public double dblInReturnAirCFM { get; set; }
        public double dblInReturnAirDB { get; set; }
        public double dblInReturnAirWB { get; set; }
        public double dblInReturnAirRH { get; set; }
        //Outputs
        public double dblOutSupplyAirCFM { get; set; }
        public double dblOutSupplyAirDB { get; set; }
        public double dblOutSupplyAirWB { get; set; }
        public double dblOutSupplyAirRH { get; set; }
        public bool bolOutSupplyAirCondWarning { get; set; }
        public double dblOutSupplyAirPD { get; set; }
        public double dblOutSupplyAirVel { get; set; }
        public double dblOutExhaustAirCFM { get; set; }
        public double dblOutExhaustAirDB { get; set; }
        public double dblOutExhaustAirWB { get; set; }
        public double dblOutExhaustAirRH { get; set; }
        public bool bolOutExhaustAirCondWar { get; set; }
        public double dblOutExhaustAirPD { get; set; }
        public double dblOutExhaustAirVel { get; set; }
        public double dblOutSensibleEffectiveness { get; set; }
        public double dblOutLatentEffectiveness { get; set; }
        public double dblOutTotalEffectiveness { get; set; }
        public bool bolOutConditionsMarginal { get; set; }
        public double dblOutTotalEnergySaved { get; set; }
        public double dblOutMoistureTransfered { get; set; }
        public double dblOutTemperatureRatio { get; set; }
        public double dblOutWaterTransferRatio { get; set; }
        public double dblOutEnergyRecoveryRatio { get; set; }
        public double dblOutPrice { get; set; }
        public string strAHRICertificationMessage { get; set; }
        public bool bolAHRICertified { get; set; }
    }
}