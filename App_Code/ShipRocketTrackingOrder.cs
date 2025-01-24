using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class ShipRocketTrackingOrder
{
    public TrackingData tracking_data { get; set; }
}

public class QcResponse
{
    public string qc_image { get; set; }
    public string qc_failed_reason { get; set; }
}



public class ShipmentTrack
{
    public int id { get; set; }
    public string awb_code { get; set; }
    public int courier_company_id { get; set; }
    public int shipment_id { get; set; }
    public int order_id { get; set; }
    public string pickup_date { get; set; }
    public string delivered_date { get; set; }
    public string weight { get; set; }
    public int packages { get; set; }
    public string current_status { get; set; }
    public string delivered_to { get; set; }
    public string destination { get; set; }
    public string consignee_name { get; set; }
    public string origin { get; set; }
    public object courier_agent_details { get; set; }
    public object edd { get; set; }
}

public class ShipmentTrackActivity
{
    public string date { get; set; }
    public string status { get; set; }
    public string activity { get; set; }
    public string location { get; set; }

    [JsonProperty("sr-status")]
    public string SrStatus { get; set; }

    [JsonProperty("sr-status-label")]
    public string SrStatusLabel { get; set; }
}

public class TrackingData
{
    public int track_status { get; set; }
    public int shipment_status { get; set; }
    public List<ShipmentTrack> shipment_track { get; set; }
    public List<ShipmentTrackActivity> shipment_track_activities { get; set; }
    public string track_url { get; set; }
    public string etd { get; set; }
    public QcResponse qc_response { get; set; }
}


public class ShipRocketToken
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public int company_id { get; set; }
    public string created_at { get; set; }
    public string token { get; set; }
}


public class ShipRocketCreateOrderResponse
{
    public int order_id { get; set; }
    public int shipment_id { get; set; }
    public string status { get; set; }
    public int status_code { get; set; }
    public int onboarding_completed_now { get; set; }
    public string awb_code { get; set; }
    public string courier_company_id { get; set; }
    public string courier_name { get; set; }
}