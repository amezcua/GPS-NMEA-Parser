using System;

namespace DonaDona.Device.GPS
{
	/// <summary>
	/// Represents a GPGLL Gps Sentence.
	/// </summary>
	public class GPGLLGpsSentence : GpsSentenceBase
	{
		private bool _fixed;
		private LatitudeLongitude _latitude;
		private LatitudeLongitude _longitude;
		private TimeSpan _uTCPosition;
		
		/// <summary>
		/// Sentence constructor
		/// </summary>
		public GPGLLGpsSentence(string Sentence) : base(Sentence)
		{
			// Base
			this.SentenceName = "$GPGLL";
			this.Description = "Geographic Position - Latitude/Longitude";

			// Instance
			_fixed = isFixed(this.Words[6]);
			_latitude = new LatitudeLongitude(this.Words[1], this.Words[2]);
			_longitude = new LatitudeLongitude(this.Words[3], this.Words[4]);

			if(this.Words[5].Length == 6)
			{
				// Only HHMMSS
				_uTCPosition = new TimeSpan(
					0,
					int.Parse(this.Words[5].Substring(0, 2)),
					int.Parse(this.Words[5].Substring(2, 2)),
					int.Parse(this.Words[5].Substring(4, 2)));
			}
			else
			{
				// HHMMSS.MS
				_uTCPosition = new TimeSpan(
					0,
					int.Parse(this.Words[5].Substring(0, 2)),
					int.Parse(this.Words[5].Substring(2, 2)),
					int.Parse(this.Words[5].Substring(4, 2)),
					int.Parse(this.Words[5].Substring(7)));
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
		/// Returns the UtcPosition reported.
		/// </summary>
		public TimeSpan UtcPosition
		{
			get
			{
				return _uTCPosition;
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
