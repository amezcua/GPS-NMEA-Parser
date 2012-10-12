using System;

namespace DonaDona.Device.GPS
{
	/// <summary>
	/// Represents a GPGSV Gps Sentence.
	/// </summary>
	public class GPGSVGpsSentence : GpsSentenceBase
	{
		private int _numberOfMessages; // This sentence comes in a few consecutive messages.
		private int _messageNumber; // Number of this message in the block
		private int _satellitesInView; // Number of visible satellites
		private SatelliteInView[] _satellites; // Information about the satellites in this sentence

		private int _satelliteCountInSentence;
		
		/// <summary>
		/// Sentence constructor
		/// </summary>
		public GPGSVGpsSentence(string Sentence) : base(Sentence)
		{
			// Base
			this.SentenceName = "$GPGSV";
			this.Description = "GNSS Satellites in View";

			// Instance
			_numberOfMessages = int.Parse(this.Words[1]);
			_messageNumber = int.Parse(this.Words[2]);
			_satellitesInView = int.Parse(this.Words[3]);

			_satelliteCountInSentence = (this.WordCount - 3) / 4;

			_satellites = new SatelliteInView[_satelliteCountInSentence];

			int satelliteWordIndex = 4;
			int currentIndex;
			for(int i=0; i < _satelliteCountInSentence; i++)
			{
				_satellites[i] = new SatelliteInView();
				currentIndex = satelliteWordIndex;
				if(this.Words[currentIndex] != String.Empty)
					_satellites[i].SatelliteID = int.Parse(this.Words[currentIndex]);
				satelliteWordIndex ++;
				
				currentIndex = satelliteWordIndex;
				if(this.Words[currentIndex] != String.Empty)
					_satellites[i].Elevation = double.Parse(this.Words[currentIndex]);
				satelliteWordIndex ++;

				currentIndex = satelliteWordIndex;
				if(this.Words[currentIndex] != String.Empty)
					_satellites[i].Azimuth = double.Parse(this.Words[currentIndex]);
				satelliteWordIndex ++;
				
				currentIndex = satelliteWordIndex;
				if(this.Words[currentIndex] != String.Empty)
					_satellites[i].SignalToNoiseRatio = double.Parse(this.Words[currentIndex]);
				satelliteWordIndex ++;
			}
		}
		
		public int NumberOfMessages
		{
			get
			{
				return _numberOfMessages;
			}
		}

		public int MessageNumber
		{
			get
			{
				return _messageNumber;
			}
		}

		public int SatellitesInView
		{
			get
			{
				return _satellitesInView;
			}
		}

		public SatelliteInView[] Satellites
		{
			get
			{
				return _satellites;
			}
		}
		
	}
}
