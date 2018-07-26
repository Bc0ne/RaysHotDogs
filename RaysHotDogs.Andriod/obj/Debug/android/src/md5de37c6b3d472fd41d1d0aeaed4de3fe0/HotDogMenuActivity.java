package md5de37c6b3d472fd41d1d0aeaed4de3fe0;


public class HotDogMenuActivity
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
		mono.android.Runtime.register ("RaysHotDogs.Andriod.HotDogMenuActivity, RaysHotDogs.Andriod", HotDogMenuActivity.class, __md_methods);
	}


	public HotDogMenuActivity ()
	{
		super ();
		if (getClass () == HotDogMenuActivity.class)
			mono.android.TypeManager.Activate ("RaysHotDogs.Andriod.HotDogMenuActivity, RaysHotDogs.Andriod", "", this, new java.lang.Object[] {  });
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
