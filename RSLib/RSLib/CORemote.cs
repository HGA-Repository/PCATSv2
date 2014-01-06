using System;
using System.Runtime.CompilerServices;
namespace RSLib
{
	public class CORemote : MarshalByRefObject
	{
		public event ServiceCallEvent OnServiceCall
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.OnServiceCall = (ServiceCallEvent)Delegate.Combine(this.OnServiceCall, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.OnServiceCall = (ServiceCallEvent)Delegate.Remove(this.OnServiceCall, value);
			}
		}
		public void PerformSpecifiedService(int svc)
		{
			FUY_List fUY_List = new FUY_List();
			fUY_List.ShowDialog();
			if (this.OnServiceCall != null)
			{
				this.OnServiceCall(svc);
			}
		}
	}
}
