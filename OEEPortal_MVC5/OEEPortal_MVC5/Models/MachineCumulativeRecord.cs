using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class MachineCumulativeRecord
    {
        public String Machine { get; set; }
        public double UsefulTime { get; set; } 


        public int TotalQuantity {get;set;}
        public int GoodQuantity {get;set;}
        public int DefectQuantity {get;set;}

        public double QualityDefectTime {get;set;}
        public double QualityRate {get;set;}


        public double RT {get;set;}
        public double PerformanceLossTime {get;set;}
        public double PerformanceRate {get;set;}
        public double UPT {get;set;}

       

        public double EquipmentBreakdown {get;set;}
        public double ChangeOver {get;set;}
        public double MaterialShortage {get;set;}
        public double QualityDowntime {get;set;}
        public double NonProductionTime {get;set;}
        public double AvailabilityRate{get;set;}

        public double SPT {get;set;}
        public double OEE {get;set;}
        
        public double PreventiveMaintenance{get;set;}
        public double ManagementMeeting {get;set;}
        public double RegulatoryBreaks {get;set;}
        public double PilotRun {get;set;}
        
        public double UtilizationRate{get;set;}
        public double POT {get;set;}
        public double NEE {get;set;}

        
       public MachineCumulativeRecord()
        {
            
            UsefulTime =0;


         TotalQuantity =0;
        GoodQuantity =0;
        DefectQuantity =0;

        QualityDefectTime =0;
        QualityRate=0;


        RT =0;
        PerformanceLossTime =0;
        PerformanceRate =0;
        UPT =0;

        EquipmentBreakdown =0;
        ChangeOver =0;
        MaterialShortage =0;
        QualityDowntime =0;
        NonProductionTime =0;
        AvailabilityRate=0;

        SPT =0;
        OEE =0;
        
        PreventiveMaintenance=0;
        ManagementMeeting = 0;
        RegulatoryBreaks =0;
        PilotRun = 0;
        
        UtilizationRate = 0;
        POT  = 0;
        NEE =0;
           

        }
        
    }
}