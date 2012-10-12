using System;
using System.Globalization;

namespace DonaDona.Device.GPS
{
	/// <summary>
	/// Represents a GPRMC Gps Sentence.
	/// </summary>
	public class GPRMCGpsSentence : GpsSentenceBase
	{
		private DateTime _uTCDateTime;
		private bool _fixed;
		private LatitudeLongitude _latitude;
		private LatitudeLongitude _longitude;
		private GpsSpeed _speedOverGround;
		private double _courseOverGround;
		private string _magneticVariation;
		
		/// <summary>
		/// Sentence constructor
		/// </summary>
		public GPRMCGpsSentence(string SentenceInstance) : base(SentenceInstance)
		{
			// Base
			SentenceName = "$GPRMC";
			Description = "Recommended Minimum Specific GPS/TRANSIT Data";

			// Instance
			_fixed = isFixed(Words[2]);
			_latitude = new LatitudeLongitude(Words[3], Words[4]);
			_longitude = new LatitudeLongitude(Words[5], Words[6]);
			_speedOverGround = new GpsSpeed(Words[7]);
			if(Words[8] == String.Empty)
			{
				_courseOverGround = -1;
			}
			else
			{
				_courseOverGround = double.Parse(Words[8], new CultureInfo("en-US"));
			}
			_magneticVariation = Words[10];

            if (Words[1].Length != 0)
            {
                try
                {
                    if (Words[1].Length == 6)
                    {
                        // Only HHMMSS
                        _uTCDateTime = new DateTime(
                            int.Parse(Words[9].Substring(4, 2)),
                            int.Parse(Words[9].Substring(2, 2)),
                            int.Parse(Words[9].Substring(0, 2)),
                            int.Parse(Words[1].Substring(0, 2)),
                            int.Parse(Words[1].Substring(2, 2)),
                            int.Parse(Words[1].Substring(4, 2)));
                    }
                    else
                    {
                        // HHMMSS.MS
                        _uTCDateTime = new DateTime(
                            int.Parse(Words[9].Substring(4, 2)),
                            int.Parse(Words[9].Substring(2, 2)),
                            int.Parse(Words[9].Substring(0, 2)),
                            int.Parse(Words[1].Substring(0, 2)),
                            int.Parse(Words[1].Substring(2, 2)),
                            int.Parse(Words[1].Substring(4, 2)),
                            int.Parse(Words[1].Substring(7)));
                    }
                }
                catch(ArgumentNullException){}
            }
		}
		
		/// <summary>
		/// Determines if the GPS has fixed its position.
		/// </summary>
		public bool Fixed
		{
			get
			{
				return _fixed;
			}
		}

		/// <summary>
		/// Returns the current DateTime reported.
		/// </summary>
		public DateTime GpsDateTime
		{
			get
			{
				return _uTCDateTime;
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

		public GpsSpeed SpeedOverGround
		{
			get
			{
				return _speedOverGround;
			}
		}

		public double CourseOverGround
		{
			get
			{
				return _courseOverGround;
			}
		}

		public string MagneticVariation
		{
			get
			{
				return _magneticVariation;
			}
		}

		/// <summary>
		/// Determines if the position is fixed.
		/// </summary>
		/// <param name="Status"></param>
		/// <returns></returns>
		private bool isFixed(string Status)
		{
			if(Status == "A")
				return true;

			return false;
		}
	}
}
