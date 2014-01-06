using System;
namespace RevSol
{
	public class RSListItem
	{
		private int miID;
		private string msDescription;
		private string msMeta;
		private string msMeta1;
		private string msMeta2;
		public int ID
		{
			get
			{
				return this.miID;
			}
			set
			{
				this.miID = value;
			}
		}
		public string Description
		{
			get
			{
				return this.msDescription;
			}
			set
			{
				this.msDescription = value;
			}
		}
		public string Meta
		{
			get
			{
				return this.msMeta;
			}
			set
			{
				this.msMeta = value;
			}
		}
		public string Meta1
		{
			get
			{
				return this.msMeta1;
			}
			set
			{
				this.msMeta1 = value;
			}
		}
		public string Meta2
		{
			get
			{
				return this.msMeta2;
			}
			set
			{
				this.msMeta2 = value;
			}
		}
		public RSListItem()
		{
			this.Clear();
		}
		public void Clear()
		{
			this.miID = 0;
			this.msDescription = "";
			this.msMeta = "";
			this.msMeta1 = "";
			this.msMeta2 = "";
		}
		public override string ToString()
		{
			return this.msDescription;
		}
		public RSListItem Clone()
		{
			return new RSListItem
			{
				ID = this.miID,
				Description = this.msDescription,
				Meta = this.msMeta,
				Meta1 = this.msMeta1,
				Meta2 = this.msMeta2
			};
		}
	}
}
