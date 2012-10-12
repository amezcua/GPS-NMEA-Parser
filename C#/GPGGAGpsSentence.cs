using System;
using System.Globalization;

namespace DonaDona.Device.GPS
{
	/// <summary>
	/// Represents a GPGGA Gps Sentence.
	/// </summary>
	public class GPGGAGpsSentence : GpsSentenceBase
	{
		private TimeSpan _uTCTime;
		private LatitudeLongitude _latitude;
		private LatitudeLongitude _longitude;
		private PositionFix _positionFix;
		private int _satelitesUsed = -1;
		private double _hDOP = -1;
		private double _altitude = -1;
		private double _geoidSeparation = -1;
		
		/// <summary>
		/// Sentence constructor
		/// </summary>
		public GPGGAGpsSentence(string Sentence) : base(Sentence)
		{
			// Base
			SentenceName = "$GPGGA";
			Description = "Global Positioning System Fixed Data";

		    var enUS = new CultureInfo("en-US");

			// Instance
			if(Words[1].Length == 6)
			{
				// Only HHMMSS
				_uTCTime = new TimeSpan(
					0,
					int.Parse(Words[1].Substring(0, 2)),
					int.Parse(Words[1].Substring(2, 2)),
					int.Parse(Words[1].Substring(4, 2)));
			}
			else
			{
				// HHMMSS.MS
				_uTCTime = new TimeSpan(
					0,
					int.Parse(Words[1].Substring(0, 2)),
					int.Parse(Words[1].Substring(2, 2)),
					int.Parse(Words[1].Substring(4, 2)),
					int.Parse(Words[1].Substring(7)));
			}

			_latitude = new LatitudeLongitude(Words[2], Words[3]);
			_longitude = new LatitudeLongitude(Words[4], Words[5]);
			if(Words[6] != string.Empty)
				_positionFix = (PositionFix) int.Parse(Words[6]);
			if(Words[7] != string.Empty)
				_satelitesUsed = int.Parse(Words[7]);
			if(Words[8] != string.Empty)
				_hDOP = double.Parse(Words[8], enUS);
			if(Words[9] != string.Empty)
				_altitude = double.Parse(Words[9], enUS);
			if(Words[11] != string.Empty)
				_geoidSeparation = double.Parse(Words[11], enUS);
		}
		
		public TimeSpan UTCTime
		{
			get
			{
				return _uTCTime;
			}
		}

		public LatitudeLongitude Latitude
		{
			get
			{
				return _latitude;
			}
		}

		public LatitudeLongitude Longitude
		{
			get
			{
				return _longitude;
			}
		}

		public PositionFix PositionFix
		{
			get
			{
				return _positionFix;
			}
		}

		public int SatelitesUsed
		{
			get
			{
				return _satelitesUsed;
			}
		}

		public double HDOP
		{
			get
			{
				return _hDOP;
			}
		}

		public double Altitude
		{
			get
			{
				return _altitude;
			}
		}

		public double GeoidSeparation
		{
			get
			{
				return _geoidSeparation;
			}
		}
	}
}
