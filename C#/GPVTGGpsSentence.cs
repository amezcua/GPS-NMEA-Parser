using System;
using System.Globalization;

namespace DonaDona.Device.GPS
{
	/// <summary>
	/// Represents a GPVTG Gps Sentence.
	/// </summary>
	public class GPVTGGpsSentence : GpsSentenceBase
	{
		private double _trueCourse;
		private double _magneticCourse;
		private double _speedKnots;
		private double _speedKmh;
		
		/// <summary>
		/// Sentence constructor
		/// </summary>
		public GPVTGGpsSentence(string Sentence) : base(Sentence)
		{
			// Base
			this.SentenceName = "$GPVTG";
			this.Description = "Course Over Ground and Ground Speed";

			// Instance
			if(this.Words[1] != String.Empty)
				_trueCourse = double.Parse(this.Words[1], new CultureInfo("en-US"));

			if(this.Words[3] != String.Empty)
				_magneticCourse = double.Parse(this.Words[3], new CultureInfo("en-US"));

			if(this.Words[5] != String.Empty)
				_speedKnots = double.Parse(this.Words[5], new CultureInfo("en-US"));

			if(this.Words[7] != String.Empty)
				_speedKmh = double.Parse(this.Words[7], new CultureInfo("en-US"));
		}
		
		public double TrueCourse
		{
			get
			{
				return _trueCourse;
			}
		}

		public double MagneticCourse
		{
			get
			{
				return _magneticCourse;
			}
		}

		public double SpeedKnots
		{
			get
			{
				return _speedKnots;
			}
		}

		public double SpeedKmH
		{
			get
			{
				return _speedKmh;
			}
		}
	}
}
