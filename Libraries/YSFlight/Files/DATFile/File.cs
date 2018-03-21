using System;
using System.Collections.Generic;
using System.Linq;

using Com.OfficerFlake.Libraries.Logger;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Extensions;

using Com.OfficerFlake.Libraries.YSFlight.Files.DAT.Properties;

namespace Com.OfficerFlake.Libraries.YSFlight.Files.DAT
{
    public partial class File : IO.CommandFile, IDATFile
    {
		#region CTOR
	    public File(string filename) : base(filename)
	    {
		    Contents = new List<IDATFileProperty>();
			CachedData = new _CachedData(this);
	    }
		#endregion
		public List<IRichTextMessage> DebugInformation = new List<IRichTextMessage>();

        public new List<IDATFileProperty> Contents { get; set; }

	    public class _CachedData : IDATFileCached
	    {
		    private File Parent = null;

		    public UInt16 AmmoGun => (UInt16)((Parent?.Contents?.Last(x => x is INITIGUN) as INITIGUN)?.Value ?? 0);
			public UInt16 Strength => (UInt16)((Parent?.Contents?.Last(x => x is STRENGTH) as STRENGTH)?.Value ?? 1);

			public _CachedData(File parent)
		    {
			    Parent = parent;
		    }

			//public Boolean AAMSLOT_ = false;
			//public Boolean AAMVISIB = false;
		    public Boolean HasAfterburner => (Parent?.Contents?.Last(x => x is AFTBURNR) as AFTBURNR)?.Value ?? false;
			public Int32 NumAGMSlots => (Parent?.Contents?.Count(x => x is AGMSLOT_)) ?? 0;
			//public Boolean AGMVISIB = false;
		    public String AircraftClass => (Parent?.Contents?.Last(x => x is AIRCLASS) as AIRCLASS)?.Value ?? "UNKNOWN";
			public Boolean HasArrestor => ((Parent?.Contents?.Count(x => x is ARRESTER)) ?? 0) > 0;
		    public ICoordinate3 PositionArrestor => (Parent?.Contents?.Last(x => x is ARRESTER) as ARRESTER)?.Value ?? ObjectFactory.CreateCoordinate3(0.Meters(), 0.Meters(), 0.Meters());
			public IOrientation3 DefaultAttitude => (Parent?.Contents?.Last(x => x is ATTITUDE) as ATTITUDE)?.Value ?? ObjectFactory.CreateOrientation3(0.Degrees(), 0.Degrees(), 0.Degrees());
			//public Boolean AUTOCALC => false;
		    public Single RadarCrossSectionBombBay => (Parent?.Contents?.Last(x => x is BMBAYRCS) as BMBAYRCS)?.Value ?? 1;
			//public Boolean BOMBSLOT => false;
		    //public Boolean BOMINBAY => false;
		    //public Boolean BOMVISIB => false;
		    public Boolean CATEGORY => false;
		    public Boolean CDBYFLAP => false;
			public Boolean CDBYGEAR => false;
		    public Boolean CDSPOILR => false;
			public Boolean CDVARGEO => false;
			public Boolean CKPITHUD => false;
		    public Boolean CKPITIST => false;
		    public Boolean CLBYFLAP => false;
		    public Boolean CLDECAY1 => false;
		    public Boolean CLDECAY2 => false;
		    public Boolean CLVARGEO => false;
			public Boolean COCKPITA => false;
		    public Boolean COCKPITP => false;
			public Boolean CPITMANE => false;
			public Boolean CPITSTAB => false;
		    public Boolean CRITAOAM => false;
			public Boolean CRITAOAP => false;
			public Boolean CRITSPED => false;
			public Boolean CROLLMAN => false;
			public Boolean CTLABRNR => false;
		    public Boolean CTLATVGW => false;
		    public Boolean CTLBRAKE => false;
		    public Boolean CTLIFLAP => false;
			public Boolean CTLINVGW => false;
		    public Boolean CTLLDGEA => false;
		    public Boolean CTLSPOIL => false;
			public Boolean CTLTHROT => false;
			public Boolean CYAWMANE => false;
			public Boolean CYAWSTAB => false;
			public Boolean EXCAMERA => false;
		    public Boolean FLAPPOSI => false;
			public Boolean FLAREPOS => false;
		    public Boolean FLATCLR1 => false;
			public Boolean FLATCLR2 => false;
			public Boolean FUELMILI => false;
			public Boolean FUELABRN => false;
			public Boolean GEARHORN => false;
		    public Boolean GUNDIREC => false;
			public Boolean GUNINTVL => false;
			public Boolean GUNPOWER => false;
			public Boolean GUNSIGHT => false;
		    public Boolean HASSPOIL => false;
		    public Boolean HRDPOINT => false;
		    public Boolean HTRADIUS => false;
			public Boolean IDENTIFY => false;
		    public Boolean INITAAMM => false;
		    public Boolean INITBOMB => false;
			public Boolean INITFUEL => false;
			public Boolean INITIAAM => false;
			public Boolean INITIAGM => false;
			public Boolean INITIGUN => false;
			public Boolean INITLOAD => false;
			public Boolean INITRCKT => false;
			public Boolean INITSPED => false;
			public Boolean INSTPANL => false;
		    public Boolean ISPNLATT => false;
		    public Boolean ISPNLHUD => false;
		    public Boolean ISPNLPOS => false;
			public Boolean ISPNLSCL => false;
			public Boolean LEFTGEAR => false;
			public Boolean LMTBYHDP => false;
		    public Boolean LOADWEPN => false;
		    public Boolean MACHNGN2 => false;
			public Boolean MACHNGN3 => false;
			public Boolean MACHNGN4 => false;
			public Boolean MACHNGN5 => false;
			public Boolean MACHNGN6 => false;
			public Boolean MACHNGN7 => false;
			public Boolean MACHNGN8 => false;
			public Boolean MACHNGUN => false;
			public Boolean MANESPD1 => false;
			public Boolean MANESPD2 => false;
			public Boolean MAXCDAOA => false;
			public Boolean MAXNAAMM => false;
			public Boolean MAXNBOMB => false;
			public Boolean MAXNMAAM => false;
			public Boolean MAXNMAGM => false;
			public Boolean MAXNMFLR => false;
			public Boolean MAXNMRKT => false;
			public Boolean MAXSPEED => false;
			public Boolean MXIPTAOA => false;
			public Boolean MXIPTROL => false;
			public Boolean MXIPTSSA => false;
			public Boolean NMTURRET => false;
			public Boolean POSITION => false;
			public Boolean PROPEFCY => false;
			public Boolean PROPELLR => false;
			public Boolean PROPVMIN => false;
			public Boolean PSTMPTCH => false;
			public Boolean PSTMPWR1 => false;
			public Boolean PSTMPWR2 => false;
			public Boolean PSTMROLL => false;
			public Boolean PSTMSPD1 => false;
			public Boolean PSTMSPD2 => false;
			public Boolean PSTMYAW_ => false;
			public Boolean RADARCRS => false;
			public Boolean REFACRUS => false;
			public Boolean REFAOALD => false;
			public Boolean REFLNRWY => false;
			public Boolean REFTCRUS => false;
			public Boolean REFTHRLD => false;
			public Boolean REFVCRUS => false;
			public Boolean REFVLAND => false;
			public Boolean RETRGEAR => false;
		    public Boolean RIGHGEAR => false;
			public Boolean RKTSLOT_ => false;
			public Boolean RKTVISIB => false;
		    public Boolean SCRNCNTR => false;
		    public Boolean SMOKECOL => false;
		    public Boolean SMOKEGEN => false;
			public Boolean SMOKEOIL => false;
			public Boolean STALHORN => false;
		    public Boolean STRENGTH => false;
			public Boolean SUBSTNAM => false;
		    public Boolean THRAFTBN => false;
			public Boolean THRMILIT => false;
			public Boolean THRSTREV => false;
			public Boolean TRIGGER1 => false;
		    public Boolean TRIGGER2 => false;
			public Boolean TRIGGER3 => false;
			public Boolean TRIGGER4 => false;
			public Boolean TRSTDIR0 => false;
			public Boolean TRSTDIR1 => false;
			public Boolean TRSTVCTR => false;
		    public Boolean TURRETAM => false;
		    public Boolean TURRETAR => false;
			public Boolean TURRETCT => false;
		    public Boolean TURRETGD => false;
			public Boolean TURRETHD => false;
		    public Boolean TURRETIV => false;
		    public Boolean TURRETNM => false;
		    public Boolean TURRETPO => false;
		    public Boolean TURRETPT => false;
		    public Boolean TURRETRG => false;
		    public Boolean VAPORPO0 => false;
		    public Boolean VAPORPO1 => false;
		    public Boolean VARGEOMW => false;
		    public Boolean VGWSPED1 => false;
			public Boolean VGWSPED2 => false;
			public Boolean VRGMNOSE => false;
		    public Boolean WEAPONCH => false;
		    public Boolean WEIGFUEL => false;
		    public IMass WeightOfFuel => (Parent?.Contents?.Last(x => x is WEIGFUEL) as WEIGFUEL)?.Value ?? 0.KiloGrams();
			public Boolean WEIGHCLN => false;
			public Boolean WEIGLOAD => false;
			public Boolean WHELGEAR => false;
			public Boolean WINGAREA => false;
			public Boolean WPNSHAPE => false;
	    }
		public IDATFileCached CachedData { get; set; }

		public new bool Load()
        {
	        Contents.Clear();
            base.Load();
            for(int i=0; i < base.Contents.Count; i++)
            {
	            ICommandFileLine thisLine = base.Contents[i];
                if (thisLine.Command == "") continue;
                if (Extensions.YSFlight.CommentMarkers.StartOfLineMarkers.Any(x=> thisLine.Command.StartsWith(x))) continue;
                #region ThisLine => Dat Property

	            switch (thisLine.Command)
	            {
		            case "AAMSLOT_":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new AAMSLOT_(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
		            case "AAMVISIB":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new AAMVISIB(value));
			            continue;
		            }
		            case "AFTBURNR":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new AFTBURNR(value));
			            continue;
		            }
		            case "AGMSLOT_":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new AGMSLOT_(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
		            case "AGMVISIB":
		            {
			            Boolean value;
			            if (!Boolean.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new AGMVISIB(value));
			            continue;
		            }
		            case "AIRCLASS":
		            {
			            String value = thisLine.GetParameter(0);
			            Contents.Add(new AIRCLASS(value));
			            continue;
		            }
		            case "ARRESTER":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new ARRESTER(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
		            case "ATTITUDE":
		            {
			            IAngle h;
			            IAngle p;
			            IAngle b;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out h)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out p)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out b)) goto Error;
			            Contents.Add(new ATTITUDE(ObjectFactory.CreateOrientation3(h, p, b)));
			            continue;
		            }
		            case "AUTOCALC":
		            {
			            Contents.Add(new AUTOCALC());
			            continue;
		            }
		            case "BMBAYRCS":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new BMBAYRCS(value));
			            continue;
		            }
		            case "BOMBSLOT":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new BOMBSLOT(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
		            case "BOMINBAY":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new BOMINBAY(value));
			            continue;
		            }
		            case "BOMVISIB":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new BOMVISIB(value));
			            continue;
		            }
		            case "CATEGORY":
		            {
			            IYSTypeAircraftCategory value = Extensions.YSFlight.AircraftCategories.GetCategoryFromStringOrBlank(thisLine.GetParameter(0), thisLine.GetParameter(1));
			            Contents.Add(new CATEGORY(value));
			            continue;
		            }
		            case "CDBYFLAP":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CDBYFLAP(value));
						continue;
					}
					case "CDBYGEAR":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new CDBYGEAR(value));
			            continue;
		            }
		            case "CDSPOILR":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CDSPOILR(value));
						continue;
					}
					case "CDVARGEO":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CDVARGEO(value));
						continue;
					}
					case "CKPITHUD":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new CKPITHUD(value));
			            continue;
		            }
		            case "CKPITIST":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new CKPITIST(value));
			            continue;
		            }
		            case "CLBYFLAP":
		            {
						Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new CLBYFLAP(value));
			            continue;
					}
		            case "CLDECAY1":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new CLDECAY1(value));
			            continue;
		            }
		            case "CLDECAY2":
		            {
						IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new CLDECAY2(value));
			            continue;
					}
		            case "CLVARGEO":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CLVARGEO(value));
						continue;
					}
					case "COCKPITA":
		            {
			            IAngle h;
			            IAngle p;
			            IAngle b;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out h)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out p)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out b)) goto Error;
			            Contents.Add(new COCKPITA(ObjectFactory.CreateOrientation3(h, p, b)));
			            continue;
		            }
		            case "COCKPITP":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new COCKPITP(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "CPITMANE":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CPITMANE(value));
						continue;
					}
					case "CPITSTAB":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(),
				            out value)) goto Error;
			            Contents.Add(new CPITSTAB(value));
			            continue;
		            }
		            case "CRITAOAM":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new CRITAOAM(value));
			            continue;
		            }
					case "CRITAOAP":
					{
						IAngle value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new CRITAOAP(value));
						continue;
					}
					case "CRITSPED":
					{
						ISpeed value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new CRITSPED(value));
						continue;
					}
					case "CROLLMAN":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CROLLMAN(value));
						continue;
					}
					case "CTLABRNR":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new CTLABRNR(value));
			            continue;
		            }
		            case "CTLATVGW":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new CTLATVGW(value));
			            continue;
		            }
		            case "CTLBRAKE":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new CTLBRAKE(value));
			            continue;
		            }
		            case "CTLIFLAP":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CTLIFLAP(value));
						continue;
					}
					case "CTLINVGW":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(),
				            out value)) goto Error;
			            Contents.Add(new CTLINVGW(value));
			            continue;
		            }
		            case "CTLLDGEA":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new CTLLDGEA(value));
			            continue;
		            }
		            case "CTLSPOIL":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CTLSPOIL(value));
						continue;
					}
					case "CTLTHROT":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CTLTHROT(value));
						continue;
					}
					case "CYAWMANE":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CYAWMANE(value));
						continue;
					}
					case "CYAWSTAB":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new CYAWSTAB(value));
						continue;
					}
					case "EXCAMERA":
		            {
			            String name;
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            IAngle h;
			            IAngle p;
			            IAngle b;
			            Boolean isInside = false;
			            name = thisLine.GetParameter(0);
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(3), out z)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(4), out h)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(5), out p)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(6), out b)) goto Error;
			            if (thisLine.GetParameter(7) == "INSIDE") isInside = true;
			            Contents.Add(new EXCAMERA(name, ObjectFactory.CreateCoordinate3(x, y, z),
				            ObjectFactory.CreateOrientation3(h, p, b), isInside));
			            continue;
		            }
		            case "FLAPPOSI":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new FLAPPOSI(value));
						continue;
					}
					case "FLAREPOS":
		            {
			            IDistance x1;
			            IDistance y1;
			            IDistance z1;
			            IDistance x2; //SECOND PARAMETER IS OPTIONAL.
			            IDistance y2;
			            IDistance z2;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x1)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y1)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z1)) goto Error;
			            ObjectFactory.TryParse(thisLine.GetParameter(3), out x2);
				        ObjectFactory.TryParse(thisLine.GetParameter(4), out y2);
				        ObjectFactory.TryParse(thisLine.GetParameter(5), out z2);
			            Contents.Add(new FLAREPOS(ObjectFactory.CreateCoordinate3(x1, y1, z1), ObjectFactory.CreateCoordinate3(x2, y2, z2)));
			            continue;
		            }
		            case "FLATCLR1":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new FLATCLR1(value));
			            continue;
		            }
					case "FLATCLR2":
					{
						IAngle value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new FLATCLR2(value));
						continue;
					}
					case "FUELMILI":
					{
						IMass value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new FUELMILI(value));
						continue;
					}
					case "FUELABRN":
					{
						IMass value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new FUELABRN(value));
						continue;
					}
					case "GEARHORN":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new GEARHORN(value));
			            continue;
		            }
		            case "GUNDIREC":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new GUNDIREC(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "GUNINTVL":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new GUNINTVL(value.Seconds()));
						continue;
					}
					case "GUNPOWER":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new GUNPOWER(value));
						continue;
					}
					case "GUNSIGHT":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new GUNSIGHT(value));
			            continue;
		            }
		            case "HASSPOIL":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new HASSPOIL(value));
			            continue;
		            }
		            case "HRDPOINT":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            var descriptors = new List<IYSTypeHardpointDescription>();
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						for (var j = 3; j < thisLine.NumberOfParameters; j++)
			            {
				            try
				            {
					            if (thisLine.GetParameter(i) == "") continue;
					            var thisDescriptor = ObjectFactory.CreateYSTypeHardpointDescription(thisLine.GetParameter(i));
					            descriptors.Add(thisDescriptor);
				            }
				            catch
				            {
					            goto Error;
				            }
			            }
			            Contents.Add(new HRDPOINT(ObjectFactory.CreateCoordinate3(x, y, z), descriptors.ToArray()));
			            continue;
		            }
		            case "HTRADIUS":
		            {
			            IDistance value;
			            if (!ObjectFactory.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new HTRADIUS(value));
			            continue;
		            }
					case "IDENTIFY":
		            {
			            String value = thisLine.GetParameter(0);
			            Contents.Add(new IDENTIFY(value));
			            continue;
		            }
		            case "INITAAMM":
		            {
			            UInt32 value;
			            if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new INITAAMM(value));
			            continue;
		            }
		            case "INITBOMB":
		            {
			            UInt32 value;
			            if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new INITBOMB(value));
			            continue;
		            }
					case "INITFUEL":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new INITFUEL(value));
			            continue;
		            }
					case "INITIAAM":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new INITIAAM(value));
						continue;
					}
					case "INITIAGM":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new INITIAGM(value));
						continue;
					}
					case "INITIGUN":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new INITIGUN(value));
						continue;
					}
					case "INITLOAD":
		            {
			            IMass value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new INITLOAD(value));
			            continue;
		            }
					case "INITRCKT":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new INITRCKT(value));
						continue;
					}
					case "INITSPED":
		            {
			            ISpeed value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new INITSPED(value));
			            continue;
		            }
					case "INSTPANL":
		            {
			            String value = thisLine.GetParameter(0);
			            Contents.Add(new INSTPANL(value));
			            continue;
		            }
		            case "ISPNLATT":
		            {
			            IAngle h;
			            IAngle p;
			            IAngle b;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out h)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out p)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out b)) goto Error;
			            Contents.Add(new ISPNLATT(ObjectFactory.CreateOrientation3(h, p, b)));
			            continue;
		            }
		            case "ISPNLHUD":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new ISPNLHUD(value));
			            continue;
		            }
		            case "ISPNLPOS":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new ISPNLPOS(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "ISPNLSCL":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new ISPNLSCL(value));
			            continue;
		            }
					case "LEFTGEAR":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new LEFTGEAR(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "LMTBYHDP":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new LMTBYHDP(value));
			            continue;
		            }
		            case "LOADWEPN":
		            {
			            IYSTypeWeaponType value = Extensions.YSFlight.WeaponTypes.GetCategoryFromStringOrBlank(thisLine.GetParameter(0));
			            if (!UInt32.TryParse(thisLine.GetParameter(1), out UInt32 quantity)) goto Error;
			            Contents.Add(new LOADWEPN(value, quantity));
			            continue;
		            }
		            case "MACHNGN2":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new MACHNGN2(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "MACHNGN3":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new MACHNGN3(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "MACHNGN4":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new MACHNGN4(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "MACHNGN5":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new MACHNGN5(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "MACHNGN6":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new MACHNGN6(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "MACHNGN7":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new MACHNGN7(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "MACHNGN8":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new MACHNGN8(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "MACHNGUN":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new MACHNGUN(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "MANESPD1":
					{
						ISpeed value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new MANESPD1(value));
						continue;
					}
					case "MANESPD2":
					{
						ISpeed value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new MANESPD2(value));
						continue;
					}
					case "MAXCDAOA":
					{
						IAngle value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new MAXCDAOA(value));
						continue;
					}
					case "MAXNAAMM":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new MAXNAAMM(value));
						continue;
					}
					case "MAXNBOMB":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new MAXNBOMB(value));
						continue;
					}
					case "MAXNMAAM":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new MAXNMAAM(value));
						continue;
					}
					case "MAXNMAGM":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new MAXNMAGM(value));
						continue;
					}
					case "MAXNMFLR":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new MAXNMFLR(value));
						continue;
					}
					case "MAXNMRKT":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new MAXNMRKT(value));
						continue;
					}
					case "MAXSPEED":
		            {
			            ISpeed value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new MAXSPEED(value));
			            continue;
		            }
					case "MXIPTAOA":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new MXIPTAOA(value));
			            continue;
		            }
					case "MXIPTROL":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new MXIPTROL(value));
			            continue;
		            }
					case "MXIPTSSA":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new MXIPTSSA(value));
			            continue;
		            }
					case "NMTURRET":
					{
						UInt32 value;
						if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new NMTURRET(value));
						continue;
					}
					case "POSITION":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new POSITION(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "PROPEFCY":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new PROPEFCY(value));
			            continue;
		            }
					case "PROPELLR":
					{
						IPower value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new PROPELLR(value));
						continue;
					}
					case "PROPVMIN":
		            {
			            ISpeed value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new PROPVMIN(value));
			            continue;
		            }
					case "PSTMPTCH":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new PSTMPTCH(value));
			            continue;
		            }
					case "PSTMPWR1":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new PSTMPWR1(value));
			            continue;
		            }
					case "PSTMPWR2":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new PSTMPWR2(value));
						continue;
					}
					case "PSTMROLL":
					{
						IAngle value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new PSTMROLL(value));
						continue;
					}
					case "PSTMSPD1":
					{
						ISpeed value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new PSTMSPD1(value));
						continue;
					}
					case "PSTMSPD2":
					{
						ISpeed value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new PSTMSPD2(value));
						continue;
					}
					case "PSTMYAW_":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new PSTMYAW_(value));
			            continue;
		            }
					case "RADARCRS":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new RADARCRS(value));
			            continue;
		            }
					case "REFACRUS":
					{
						IDistance value;
						if (!ObjectFactory.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new REFACRUS(value));
						continue;
					}
					case "REFAOALD":
		            {
			            IAngle value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new REFAOALD(value));
			            continue;
		            }
					case "REFLNRWY":
					{
						IDistance value;
						if (!ObjectFactory.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
						Contents.Add(new REFLNRWY(value));
						continue;
					}
					case "REFTCRUS":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new REFTCRUS(value));
			            continue;
		            }
					case "REFTHRLD":
					{
						Single value;
						if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
						Contents.Add(new REFTHRLD(value));
						continue;
					}
					case "REFVCRUS":
					{
						ISpeed value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new REFVCRUS(value));
						continue;
					}
					case "REFVLAND":
					{
						ISpeed value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new REFVLAND(value));
						continue;
					}
					case "RETRGEAR":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new RETRGEAR(value));
			            continue;
		            }
		            case "RIGHGEAR":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new RIGHGEAR(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "RKTSLOT_":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new RKTSLOT_(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "RKTVISIB":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new RKTVISIB(value));
			            continue;
		            }
		            case "SCRNCNTR":
		            {
			            Single x;
			            Single y;
						if (!Single.TryParse((thisLine.GetParameter(0)).ToString(), out x)) goto Error;
			            if (!Single.TryParse((thisLine.GetParameter(1)).ToString(), out y)) goto Error;
			            Contents.Add(new SCRNCNTR(x, y));
			            continue;
		            }
		            case "SMOKECOL":
		            {
			            Byte n;
			            Byte r;
			            Byte g;
			            Byte b;
			            if (!byte.TryParse(thisLine.GetParameter(0), out n)) goto Error;
			            if (!byte.TryParse(thisLine.GetParameter(1), out r)) goto Error;
			            if (!byte.TryParse(thisLine.GetParameter(2), out g)) goto Error;
			            if (!byte.TryParse(thisLine.GetParameter(3), out b)) goto Error;
			            Contents.Add(new SMOKECOL(n, ObjectFactory.CreateColor(r,g,b).Get24BitColor()));
			            continue;
		            }
		            case "SMOKEGEN":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new SMOKEGEN(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "SMOKEOIL":
					{
						IMass value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new SMOKEOIL(value));
						continue;
					}
					case "STALHORN":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new STALHORN(value));
			            continue;
		            }
		            case "STRENGTH":
		            {
			            UInt32 value;
			            if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new STRENGTH(value));
			            continue;
		            }
					case "SUBSTNAM":
		            {
			            String value = thisLine.GetParameter(0);
			            Contents.Add(new SUBSTNAM(value));
			            continue;
		            }
		            case "THRAFTBN":
		            {
			            IMass value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new THRAFTBN(value));
			            continue;
		            }
					case "THRMILIT":
					{
						IMass value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new THRMILIT(value));
						continue;
					}
					case "THRSTREV":
		            {
			            Single value;
			            if (!Single.TryParse(thisLine.GetParameter(0).ExtractNumberComponentFromMeasurementString(), out value)) goto Error;
			            Contents.Add(new THRSTREV(value));
			            continue;
		            }
					case "TRIGGER1":
					{
						IYSTypeWeaponCategory value = Extensions.YSFlight.WeaponCategories.GetCategoryFromStringOrBlank(thisLine.GetParameter(0));
			            if (value == null) goto Error;
			            Contents.Add(new TRIGGER1(value));
			            continue;
		            }
		            case "TRIGGER2":
		            {
			            IYSTypeWeaponCategory value = Extensions.YSFlight.WeaponCategories.GetCategoryFromStringOrBlank(thisLine.GetParameter(0));
			            if (value == null) goto Error;
			            Contents.Add(new TRIGGER2(value));
			            continue;
		            }
					case "TRIGGER3":
					{
						IYSTypeWeaponCategory value = Extensions.YSFlight.WeaponCategories.GetCategoryFromStringOrBlank(thisLine.GetParameter(0));
						if (value == null) goto Error;
						Contents.Add(new TRIGGER3(value));
						continue;
					}
					case "TRIGGER4":
					{
						IYSTypeWeaponCategory value = Extensions.YSFlight.WeaponCategories.GetCategoryFromStringOrBlank(thisLine.GetParameter(0));
						if (value == null) goto Error;
						Contents.Add(new TRIGGER4(value));
						continue;
					}
					case "TRSTDIR0":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new TRSTDIR0(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "TRSTDIR1":
					{
						IDistance x;
						IDistance y;
						IDistance z;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
						Contents.Add(new TRSTDIR1(ObjectFactory.CreateCoordinate3(x, y, z)));
						continue;
					}
					case "TRSTVCTR":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new TRSTVCTR(value));
			            continue;
		            }
		            case "TURRETAM":
		            {
			            UInt32 quantifier;
			            UInt32 value;
			            if (!UInt32.TryParse(thisLine.GetParameter(0), out quantifier))goto Error;
			            if (!UInt32.TryParse(thisLine.GetParameter(1), out value)) goto Error;
			            Contents.Add(new TURRETAM(quantifier, value));
			            continue;
		            }
		            case "TURRETAR":
		            {
			            UInt32 value;
			            if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new TURRETAR(value));
			            continue;
		            }
					case "TURRETCT":
		            {
			            UInt32 quantifier;
			            String value;
						if (!UInt32.TryParse(thisLine.GetParameter(0), out quantifier)) goto Error;
			            value = thisLine.GetParameter(1);
			            Contents.Add(new TURRETCT(quantifier, value));
			            continue;
		            }
		            case "TURRETGD":
		            {
			            UInt32 value;
			            if (!UInt32.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new TURRETGD(value));
			            continue;
		            }
					case "TURRETHD":
		            {
			            UInt32 quantifier;
			            IAngle h;
			            IAngle p;
			            IAngle b;
			            if (!uint.TryParse(thisLine.GetParameter(0), out quantifier)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out h)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out p)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(3), out b)) goto Error;
			            Contents.Add(new TURRETHD(quantifier, ObjectFactory.CreateOrientation3(h, p, b)));
			            continue;
		            }
		            case "TURRETIV":
		            {
			            UInt32 quantifier;
			            Single interval;
			            if (!UInt32.TryParse(thisLine.GetParameter(0), out quantifier)) goto Error;
			            if (!Single.TryParse(thisLine.GetParameter(1), out interval)) goto Error;
			            Contents.Add(new TURRETIV(quantifier, interval.Seconds()));
			            continue;
		            }
		            case "TURRETNM":
		            {
			            UInt32 quantifier;
			            String name;
						if (!UInt32.TryParse(thisLine.GetParameter(0), out quantifier)) goto Error;
			            name = thisLine.GetParameter(1);
			            Contents.Add(new TURRETNM(quantifier, name));
			            continue;
		            }
		            case "TURRETPO":
		            {
			            UInt32 quantifier;
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            IAngle h;
			            IAngle p;
			            IAngle b;
			            if (!UInt32.TryParse(thisLine.GetParameter(0), out quantifier)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(3), out z)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(4), out h)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(5), out p)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(6), out b)) goto Error;
			            Contents.Add(new TURRETPO(quantifier, ObjectFactory.CreateCoordinate3(x, y, z), ObjectFactory.CreateOrientation3(h, p, b)));
			            continue;
		            }
		            case "TURRETPT":
		            {
						UInt32 quantifier;
						IAngle h;
			            IAngle p;
			            IAngle b;
						if (!UInt32.TryParse(thisLine.GetParameter(0), out quantifier)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out h)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out p)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(3), out b)) goto Error;
			            Contents.Add(new TURRETPT(quantifier, ObjectFactory.CreateOrientation3(h, p, b)));
			            continue;
		            }
		            case "TURRETRG":
		            {
						UInt32 quantifier;
						IDistance value;
			            if (!UInt32.TryParse(thisLine.GetParameter(0), out quantifier)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out value)) goto Error;
			            Contents.Add(new TURRETRG(quantifier, value));
			            continue;
		            }
		            case "VAPORPO0":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new VAPORPO0(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
		            case "VAPORPO1":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new VAPORPO1(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
		            case "VARGEOMW":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new VARGEOMW(value));
			            continue;
		            }
		            case "VGWSPED1":
		            {
			            ISpeed value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new VGWSPED1(value));
			            continue;
		            }
					case "VGWSPED2":
					{
						ISpeed value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new VGWSPED2(value));
						continue;
					}
					case "VRGMNOSE":
		            {
			            Boolean value;
			            if (!Boolean.TryParse((thisLine.GetParameter(0)).ToString(), out value)) goto Error;
			            Contents.Add(new VRGMNOSE(value));
			            continue;
		            }
		            case "WEAPONCH":
		            {
			            IYSTypeWeaponCategory value = Extensions.YSFlight.WeaponCategories.GetCategoryFromStringOrBlank(thisLine.GetParameter(0));
			            Contents.Add(new WEAPONCH(value));
			            continue;
		            }
		            case "WEIGFUEL":
		            {
			            IMass value;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
			            Contents.Add(new WEIGFUEL(value));
			            continue;
		            }
					case "WEIGHCLN":
					{
						IMass value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new WEIGHCLN(value));
						continue;
					}
					case "WEIGLOAD":
					{
						IMass value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new WEIGLOAD(value));
						continue;
					}
					case "WHELGEAR":
		            {
			            IDistance x;
			            IDistance y;
			            IDistance z;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out x)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(1), out y)) goto Error;
			            if (!ObjectFactory.TryParse(thisLine.GetParameter(2), out z)) goto Error;
			            Contents.Add(new WHELGEAR(ObjectFactory.CreateCoordinate3(x, y, z)));
			            continue;
		            }
					case "WINGAREA":
					{
						IArea value;
						if (!ObjectFactory.TryParse(thisLine.GetParameter(0), out value)) goto Error;
						Contents.Add(new WINGAREA(value));
						continue;
					}
					case "WPNSHAPE":
					{
						IYSTypeWeaponType value = Extensions.YSFlight.WeaponTypes.GetCategoryFromStringOrBlank(thisLine.GetParameter(0));
			            if (value == null) goto Error;
			            var isStatic = (((thisLine.GetParameter(1)).ToString()) == "STATIC");
			            var shape = (thisLine.GetParameter(2)).ToString();
			            Contents.Add(new WPNSHAPE(value, isStatic, shape));
			            continue;
		            }
		            default:
		            {
			            Debug.AddWarningMessage("DAT COMMAND NOT IMPLEMENTED : " + thisLine);
			            continue;
		            }
			        Error:
		            {
			            Debug.AddDetailMessage("BAD DAT COMMAND? : " + thisLine);
			            continue;
		            }
				}

	            #endregion
            }
	        return true;
        }
        public new bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
