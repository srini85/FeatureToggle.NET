namespace FeatureToggle.NET
{
    public interface IToggledFeature
    {
	    bool IsToggledOn();
    }
}

/*


public interface ISomeFeature
{
	void DoSomething()
}


[ToggledFeature(Name = "EnhancementX", WhenToggled=true)]
public class MyNewFeature : ISomeFeature
{
	public void DoSomething() 
	{
	}
}

[Feature(Name = "EnhancementX", WhenToggled=false)]
public class MyExistingFeature : ISomeFeature
{
	public void DoSomething() 
	{
	}
}

UnityContainer.RegisterToggledFeature<ISomeFeature>()

public void Resolve()
{
	var env = CheckEnvironment();
	LoadVersionBasedOnEnvironment(env);
}






*/
