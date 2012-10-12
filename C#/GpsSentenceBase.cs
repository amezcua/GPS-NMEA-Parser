using System;

namespace DonaDona.Device.GPS
{
	public abstract class GpsSentenceBase
	{
		private string _sentenceInstance = String.Empty;
		private string _inferredSentenceName = String.Empty;
		private string _inferredTalkerID = String.Empty;
		private string _inferredSentenceID = String.Empty;
		private string _sentenceName = String.Empty;
		private string _description = String.Empty;
		private int _wordCount = -1;
		private string _checkSum = String.Empty;
		private string[] _words;
		
		public GpsSentenceBase(string SentenceInstance)
		{
			_sentenceInstance = SentenceInstance;

			string[] checksumSplit = SentenceInstance.Split("*".ToCharArray());

			_checkSum = checksumSplit[1];

            _words = checksumSplit[0].Split(",".ToCharArray());
			_wordCount = _words.Length -1;

			// Infer the sentence
			_inferredSentenceName = _words[0];
			_inferredTalkerID = _words[0].Substring(1, 2);
			_inferredSentenceName = _words[0].Substring(3, 3);

		}
		
		public string SentenceInstance
		{
			get
			{
				return _sentenceInstance;
			}
			set
			{
				_sentenceInstance = value;
			}
		}

		public string SentenceName
		{
			get
			{
				return _sentenceName;
			}
			set
			{
				_sentenceName = value;
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		protected string[] Words
		{
			get
			{
				return _words;
			}
		}

		public int WordCount
		{
			get
			{
				return _wordCount;
			}
			set
			{
				_wordCount = value;
			}
		}

		public string CheckSum
		{
			get
			{
				return _checkSum;
			}
			set
			{
				_checkSum = value;
			}
		}

		public abstract bool Parse();
		
		// Calculates the checksum for a sentence
		public static string GetChecksum(string sentence)
		{
			// Loop through all chars to get a checksum
			int Checksum = 0;
			foreach (char Character in sentence)
			{
				if (Character == '$')
				{
					// Ignore the dollar sign
				}
				else if (Character == '*')
				{
					// Stop processing before the asterisk
					break;
				}
				else
				{
					// Is this the first value for the checksum?
					if (Checksum == 0)
					{
						// Yes. Set the checksum to the value
						Checksum = Convert.ToByte(Character);
					}
					else
					{
						// No. XOR the checksum with this character's value
						Checksum = Checksum ^ Convert.ToByte(Character);
					}
				}
			}
			// Return the checksum formatted as a two-character hexadecimal
			return Checksum.ToString("X2");
		}
	}
	
}
