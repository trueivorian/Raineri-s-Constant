# **ICU Game Dev Soc Project Repository**
# Title: Raineri’s Constant

## For the Gameplay Programmers
Please refer to the class hierarchy diagram in the project specification:

  https://docs.google.com/document/d/18jdc1CTjqWHOvvTPKp3Yxa2g4ctDTjgEZDsivXsKPBI/edit?usp=sharing

I have put in place a very rigorous object hierarchy with the rationale being that abstracting the implementation of the concepts featured in the game would make the project easier to code. 

When making a contribution to the project please create your own branch listing the changes that you made so that they can be committed to the master branch by me.

Comment your code wherever possible and please use meaningful variable names that follow the convention that I've put in place
> Class names - CamelCaps

> Variable Identifiers - camelCaps

**Github Convention:**
As part of version control, we will be implementing this github convention so as to ensure everything stays smooth.

The ```master``` branch will only contain **workable** set of codes for a certain version of Unity. We will implement the version control in the future with tags, but currently, it will remain as it is.

The ```devel``` branch will contain all merges from working branches of developers. This branch contain codes that might not work as it implements the various features coded by developers.

Every individual coders will develop and use their own set of branch, primarily using the convention ```feat/{feature}``` to mark the feature they are working on. For instance, if I am working on the QueueManager feature, I will use ```feat/QueueManager``` branch to commit my changes. Once the feature is completed, I will pull a request to merge it with the ```devel```  branch. 

Currently, all pull requests require **reviews** by at least an approver, before the feature is merged into the branch. Do shout out on Slack when you have pulled a request in case the approvers did not see the requests in time.

## GamePlay Reminder
>  Society: The game will be set up as a society, which will initially be run autonomously by NPCs who can be replaced by players.

> Time Travel: Events will be set up allowing players to go back to when decisions were made and will be given an option to alter history in order to gain access to an alternate reality. Each reality iteration deviates from the next through decisions made in particular events.

> Massively multiplayer: Players or different abilities and game progress will interact with each other.

## For the Network Programmers
...coming soon...


