package md55436c99ee8988f7eba7a69b3ef9ea891;


public class M6Activity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Solution1._0.M6Activity, Solution1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", M6Activity.class, __md_methods);
	}


	public M6Activity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == M6Activity.class)
			mono.android.TypeManager.Activate ("Solution1._0.M6Activity, Solution1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
