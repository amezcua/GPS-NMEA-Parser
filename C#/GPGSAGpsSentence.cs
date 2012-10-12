using System.Globalization;

namespace DonaDona.Device.GPS
{
	/// <summary>
	/// Represents a GPGSA Gps Sentence.
	/// </summary>
	public class GPGSAGpsSentence : GpsSentenceBase
	{
		private Mode1 _mode1;
		private Mode2 _mode2;
		private int _satelliteOnChannel1 = -1;
		private int _satelliteOnChannel2 = -1;
		private int _satelliteOnChannel3 = -1;
		private int _satelliteOnChannel4 = -1;
		private int _satelliteOnChannel5 = -1;
		private int _satelliteOnChannel6 = -1;
		private int _satelliteOnChannel7 = -1;
		private int _satelliteOnChannel8 = -1;
		private int _satelliteOnChannel9 = -1;
		private int _satelliteOnChannel10 = -1;
		private int _satelliteOnChannel11 = -1;
		private int _satelliteOnChannel12 = -1;
		private double _pDOP = -1; // Position dillution of precision
		private double _hDOP = -1; // Horizontal dillution of precision
		private double _vDOP = -1; // Vertical dillution of precision
		
		/// <summary>
		/// Sentence constructor
		/// </summary>
		/// <param name="Sentence"></param>
		public GPGSAGpsSentence(string Sentence) : base(Sentence)
		{
			// Base
			this.SentenceName = "$GPGSA";
			this.Description = "GNSS DOP and Active Satellites";

			// Instance
			_mode1 = parseMode1(this.Words[1]);
			_mode2 = (Mode2)int.Parse(this.Words[2]);

			int currentWordPos = 2;

			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel1 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel2 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel3 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel4 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel5 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel6 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel7 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel8 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel9 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel10 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel11 = int.Parse(this.Words[currentWordPos]);
			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_satelliteOnChannel12 = int.Parse(this.Words[currentWordPos]);

			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_pDOP = double.Parse(this.Words[currentWordPos], new CultureInfo("en-US"));

			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_hDOP = double.Parse(this.Words[currentWordPos], new CultureInfo("en-US"));

			currentWordPos ++;
			if(this.Words[currentWordPos] != string.Empty)
				_vDOP = double.Parse(this.Words[currentWordPos], new CultureInfo("en-US"));
			
		}
		
		public Mode1 Mode1
		{
			get
			{
				return _mode1;
			}
		}

		public Mode2 Mode2
		{
			get
			{
				return _mode2;
			}
		}

		public int SatelliteOnChannel1
		{
			get
			{
				return _satelliteOnChannel1;
			}
		}

		public int SatelliteOnChannel2
		{
			get
			{
				return _satelliteOnChannel2;
			}
		}

		public int SatelliteOnChannel3
		{
			get
			{
				return _satelliteOnChannel3;
			}
		}

		public int SatelliteOnChannel4
		{
			get
			{
				return _satelliteOnChannel4;
			}
		}

		public int SatelliteOnChannel5
		{
			get
			{
				return _satelliteOnChannel5;
			}
		}

		public int SatelliteOnChannel6
		{
			get
			{
				return _satelliteOnChannel6;
			}
		}

		public int SatelliteOnChannel7
		{
			get
			{
				return _satelliteOnChannel7;
			}
		}

		public int SatelliteOnChannel8
		{
			get
			{
				return _satelliteOnChannel8;
			}
		}

		public int SatelliteOnChannel9
		{
			get
			{
				return _satelliteOnChannel9;
			}
		}

		public int SatelliteOnChannel10
		{
			get
			{
				return _satelliteOnChannel10;
			}
		}

		public int SatelliteOnChannel11
		{
			get
			{
				return _satelliteOnChannel11;
			}
		}

		public int SatelliteOnChannel12
		{
			get
			{
				return _satelliteOnChannel12;
			}
		}

		public double PDOP
		{
			get
			{
				return _pDOP;
			}
		}

		public double HDOP
		{
			get
			{
				return _hDOP;
			}
		}

		public double VDOP
		{
			get
			{
				return _vDOP;
			}
		}

		private Mode1 parseMode1(string Mode1String)
		{
			if(Mode1String == "M")
				return Mode1.Manual;

			return Mode1.Automatic;
		}
		
	}
}
