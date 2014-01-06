using System;
using System.Collections;
namespace RevSol
{
	public class CMenuButtons : CollectionBase
	{
		public CMenuButton this[int index]
		{
			get
			{
				return (CMenuButton)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}
		public int Add(CMenuButton menuButton)
		{
			return base.List.Add(menuButton);
		}
		public void Remove(CMenuButton menuButton)
		{
			base.List.Remove(menuButton);
		}
	}
}
