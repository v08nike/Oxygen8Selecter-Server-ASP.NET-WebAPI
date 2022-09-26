using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class ClsDBT
    {
        //------------------------------------------------------------------------------
        //SAVING
        //------------------------------------------------------------------------------
        public static string strSavJob = "sav_job";
        public static string strSavGeneral = "sav_general";
        public static string strSavAirFlowData = "sav_air_flow_data";
        public static string strSavCompOption = "sav_component_option";
        public static string strSavCompOptionCustom = "sav_component_option_custom";
        public static string strSavLayout = "sav_layout";
        public static string strSavQuote = "sav_quote";
        public static string strSavQuoteNotes = "sav_quote_notes";
        public static string strSavQuoteMisc = "sav_quote_misc";
        public static string strSavSubmittal = "sav_submittal";
        public static string strSavSubmittalNotes = "sav_submittal_notes";
        public static string strSavSubmittalShippingNotes = "sav_submittal_shipping_notes";
        public static string strSavCustomer = "sav_customer";
        public static string strSavUsers = "sav_users";

        public static string strSelCustomerType = "sel_customer_type";
        public static string strSelFOB_Point = "sel_fob_point";
        public static string strSelBasisOfDesign = "sel_basis_of_design";
        public static string strSelUOM = "sel_uom";
        public static string strSelWeatherData = "sel_weather_data";
        public static string strSelWeatherDesignConditions = "sel_weather_design_conditions";
        public static string strSelUnitType = "sel_unit_type";
        public static string strSelComponent = "sel_component";
        //public static string strSelSupplier = "sel_supplier";
        public static string strSelCountry = "sel_country";
        public static string strSelProductType = "sel_product_type";
        public const string strSelProductTypeUnitTypeLink = "sel_product_type_unit_type_link";
        public const string strSelProductTypeUnitTypeLocLink = "sel_product_type_unit_type_loc_link";
        public const string strSelProductTypeUnitTypeOriLink = "sel_product_type_unit_type_ori_link";


        public static string strSelAltitude = "sel_altitude";
        public static string strSelUnitHeatExchanger = "sel_unit_heat_exchanger";
        public static string strSelUnitCoolingHeating = "sel_unit_heating_cooling";

        public static string strSelGeneralApplication = "sel_general_application";
        public static string strSelGeneralLocation = "sel_general_location";
        //public static string strSelGeneralConfiguration = "sel_general_configuration";
        public static string strSelGeneralOrientation = "sel_general_orientation";
        public static string strSelControlsPreference = "sel_controls_preference";

        public static string strSelLocOriLink = "sel_location_orientation_link";


        public static string strSelElectricalVoltage = "sel_electrical_voltage";


        public static string strSelOrientOpeningsERV_SA_Link = "sel_orient_openings_erv_sa_link";
        public static string strSelHanding = "sel_handing";
        public static string strSelOpeningsERV_SA = "sel_openings_erv_sa";
        public static string strSelOpeningsERV_EA = "sel_openings_erv_ea";
        public static string strSelOpeningsERV_OA = "sel_openings_erv_oa";
        public static string strSelOpeningsERV_RA = "sel_openings_erv_ra";
        public static string strSelOpeningsERV_SA_EA_Link = "sel_openings_erv_sa_ea_link";
        public static string strSelOpeningsERV_SA_OA_Link = "sel_openings_erv_sa_oa_link";
        public static string strSelOpeningsERV_SA_RA_Link = "sel_openings_erv_sa_ra_link";
        public static string strSelOpeningsFC_SA = "sel_openings_fc_sa";
        public static string strSelOpeningsFC_OA = "sel_openings_fc_oa";

        //------------------------------------------------------------------------------
        public static string strSelDamperActuator = "sel_damper_actuator";
        public static string strSelDamperSize = "sel_damper_size";

        //------------------------------------------------------------------------------
        public static string strSelFilterLocation = "sel_filter_location";
        //public static string strSelFilterType = "sel_filter_type";
        public static string strSelFilterModel = "sel_filter_model";

        public static string strSelFluidType = "sel_fluid_type";
        public static string strSelFluidConcentration = "sel_fluid_concentration";

        public static string strSelRefrigerant = "sel_refrigerant";


        //------------------------------------------------------------------------------
        public const string strSelQuoteStage = "sel_quote_stage";

        public const string strSelNovaUnitModel = "sel_nova_unit_model";
        public const string strSelNovaUnitModelDownshotIndoorEqv = "sel_nova_unit_model_downshot_indoor_eqv";
        public const string strSelNovaUnitModelBypassAccs = "sel_nova_unit_model_bypass_accs";
        public const string strSelNovaUnitModelLocOriLink = "sel_nova_unit_model_loc_ori_link";
        public const string strSelNovaElectricalData = "sel_nova_electrical_data";
        public const string strSelNovaUnitModelVoltageLink = "sel_nova_unit_model_voltage_link";
        public const string strSelNovaFixedPlateCORE_Model = "sel_nova_fixed_plate_core_model";
        //public const string strSelNovaCoilDirectCoilInputs = "sel_nova_coil_direct_coil_inputs";
        public const string strSelNovaCoilDirectCoilHWC_Inputs = "sel_nova_coil_direct_coil_hwc_inputs";
        public const string strSelNovaCoilDirectCoilCWC_Inputs = "sel_nova_coil_direct_coil_cwc_inputs";
        public const string strSelNovaCoilModineInputs = "sel_nova_coil_modine_inputs";
        public const string strSelNovaCoilRAE_Inputs = "sel_nova_coil_rae_inputs";
        public const string strSelNovaElectricHeaterModel = "sel_nova_electric_heater_model";
        public const string strSelNovaFanZIEHL_ABEGG_Model = "sel_nova_fan_ziehl_abegg_model";
        public const string strSelNovaUnitSize = "sel_nova_unit_size";
        public const string strSelNovaElecHeaterDwgCode = "sel_nova_electric_heater_dwg_code";

        public const string strSelNovaPriceUnitModel = "sel_nova_price_unit_model";
        public const string strSelNovaPriceDamper = "sel_nova_price_damper";
        public const string strSelNovaPriceAccessSection = "sel_nova_price_access_section";
        public const string strSelNovaPriceElecHeater = "sel_nova_price_electric_heater";
        public const string strSelNovaPriceHWC = "sel_nova_price_hwc";
        public const string strSelNovaPriceCWC = "sel_nova_price_cwc";
        public const string strSelNovaPriceDXC = "sel_nova_price_dxc";
        public const string strSelNovaPriceValve = "sel_nova_price_valve";


        //------------------------------------------------------------------------------        
        public static string strSelElectricHeaterInstallation = "sel_electric_heater_installation";

        public static string strSelValveAndActuator = "sel_valve_actuator";
        public static string strSelValveType = "sel_valve_type";
        //public static string strSelEKEXV_Kit = "sel_ekexv_kit";
        public static string strSelSensorPrice = "sel_sensor_price";

        //------------------------------------------------------------------------------
        //public static string strSelFanLocation = "sel_fan_location";
        //public static string strSelFanType = "sel_fan_type";


        public static string strNovaVentumSoundDataPanelTL = "sel_sound_data_panel_tl";
        public static string strNovaVentumSoundDataAbsorption = "sel_sound_data_absorption";
        public static string sel_epicor_part_number = "sel_epicor_part_number";








        //------------------------------------------------------------------------------
        //public const string strSelTerraUnitModel = "sel_terra_unit_model";
        //public const string strSelTerraElectricalData = "sel_terra_electrical_data";
        //public const string strSelTerraUnitModelVoltageLink = "sel_terra_unit_model_voltage_link";
        //public const string strSelTerraUnitModelLocOriLink = "sel_terra_unit_model_loc_ori_link";
        //public const string strSelTerraCoilRAE_DXC_Inputs = "sel_terra_coil_rae_dxc_inputs";    //User when DX + Heat pump
        //public const string strSelTerraCoilRAE_DXC_HGRC_Inputs = "sel_terra_coil_rae_dxc_hgrc_inputs"; //Used when DX + Heat Pump + HGRC
        //public const string strSelTerraCoilRAE_HGRC_Inputs = "sel_terra_coil_rae_hgrc_inputs";
        //public const string strSelTerraElectricHeaterModel = "sel_terra_electric_heater_model";
        //public const string strSelTerraElectricHeaterModelSPP = "sel_terra_electric_heater_model_spp";
        //public const string strSelTerraFanZIEHL_ABEGG_Model = "sel_terra_fan_ziehl_abegg_model";
        //public const string strSelTerraElecHeaterDwgCode = "sel_terra_electric_heater_dwg_code";
        //public const string strSelTerraUnitSize = "sel_terra_unit_size";

        //public const string strSelTerraPriceUnitModel = "sel_terra_price_unit_model";
        ////public const string strSelTeraPriceDamper = "sel_nova_price_damper";
        ////public const string strSelNovaPriceAccessSection = "sel_nova_price_access_section";
        //public const string strSelTerraPriceElecHeater = "sel_terra_price_electric_heater";
        //public const string strSelTerraPriceDXC = "sel_terra_price_dxc";
        ////public const string strSelNovaPriceValve = "sel_nova_price_valve";


        //------------------------------------------------------------------------------
        //WHERE Clauses
        //------------------------------------------------------------------------------
        public static int intEnabled = 1;
        public static string strEnabled = " WHERE enabled = 1";
        public static string strOrEnabled = " OR enabled = 1";
        public static string strOrID = " OR id = ";
        public static string strOrEnabledOrID = " OR enabled = 1 OR id = ";
    }
}