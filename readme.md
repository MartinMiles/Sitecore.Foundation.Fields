# Sitecore.Foundation.Fields

Custom field(s) ready-to-use with your Sitecore solution.

### Prerequisites

This repository is configured to work with **Sitecore 9.0 Update 2** by default. If you are working with any of later versions - please update NuGet packages to appropriate version.

This package contains serialized item to be synced into **Core** database by using Unicorn with Rainbow 2.0 format.

## Role Multilist Selector field

Currently it is the only field coming with this project.

**Role Multilist Selector** is a multi-select field allowing you select numerous roles from Sitecore built-in security and mix it with regular items.
That in fact allows you creaing a various high-level subscription model or any sort of customization / personalization based on role that logged user belongs to.


![Sitecore.Foundation.Fields](https://raw.githubusercontent.com/wiki/MartinMiles/Sitecore.Foundation.Fields/images/role_selector.png "Sitecore.Foundation.Fields") 

#### Parameters

`Domain` - works as a filter for showing only roles of specific domain. 

Using **Source** column you may set it as:
```
Domain=your_sitecore_domain
```



## Related blog post

* [Roles Multilist Selector](http://blog.MartinMiles.net/post/implementing-role-selector-field-with-sitecore) - the blog post I wrote about **Roles Multilist Selector**.


### Credits

I want to warmly thank Mike Reynolds for his research re. custom fields and some of the code I've borrowed fromt him.

* [Mike Reynolds](https://sitecorejunkie.com) - great man and Sitecore MVP, who does many crazy tricks with Sitecore, ispiring others like me.


## Contact author

* [Twitter](https://twitter.com/SitecoreMartin) - Twitter
* [LinkedIn](https://www.linkedin.com/in/martin-miles/) - LinkedIn profile
* [Sitecore Slack](https://sitecorechat.slack.com/team/U0KDE1VD3/) - reference to a profiles at Sitecore Slack channel
* [Author's blog](http://blog.MartinMiles.net/) - "Experience Sitecore!" blog with plenty of interesting things about Sitecore and its implementation