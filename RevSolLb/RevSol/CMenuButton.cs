using System;
namespace RevSol
{
	public class CMenuButton
	{
		private string msIndx;
		private string msName;
		public string Indx
		{
			get
			{
				return this.msIndx;
			}
			set
			{
				this.msIndx = value;
			}
		}
		public string Name
		{
			get
			{
				return this.msName;
			}
			set
			{
				this.msName = value;
			}
		}
		public CMenuButton()
		{
			this.Clear();
		}
		public void Clear()
		{
			this.msIndx = "";
			this.msName = "";
		}
	}
}
