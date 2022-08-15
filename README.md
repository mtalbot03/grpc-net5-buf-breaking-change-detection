# Introduction 
(Setup time: 10 min)

Grpc + Buf.build and it's resilience to breaking-changes is what motivated the creation of this project.

This is the standard Greeter Grpc Demo implemented in Net 5. There is also a Net 5 client for testing purposes. 
Lastly and most interesting, there are yaml build definitions which can be imported into your own Azure Devops projects to ensure breaking changes
stay out of the main branch.
<br>
<br>
<strong>Note</strong>: You may be wondering why I'm messing around with this git tag called 'checkBreakingChanges'<br>
when I could just check against the main branch. Having this check against the main branch is ideal <br>
but I have only been able to get this working when using the tag. Feel free to give it a shot.

# Getting Started
1.	Clone the main branch
2.	Open the yml files next to the solution
3.  Edit the values to match your own Azure DevOps configuration
4.  In DevOps, add a new pipeline

![GitHub Logo](/ReadMeImages/PipelineStep1.png)


5.  Select existing yml

![GitHub Logo](/ReadMeImages/PipelineStep2.png)


6.  Select a build definition until all have been added. buf.yaml is not a build definition.
7.  After importing each yaml file, rename them to something like: Gprc_Build_Test, Check_Breaking_Changes, and Update_CheckBreakingChange_Location.
8.  Open the Update_CheckBreakingChange_Location pipepline, go to the triggers menu and deactivate CI. Add a build completion trigger on the Grpc_Build_Test pipeline on branch main

![GitHub Logo](/ReadMeImages/triggerMenu.png)


9.  Open the Check_Breaking_Changes pipeline, go to the triggers menu and deactivate CI.

![GitHub Logo](/ReadMeImages/deactivateCI.png)


10. Go to the branches page, and open the branch policies menu for branch main

![GitHub Logo](/ReadMeImages/branchPolicies.png)


11. In the Build Validation section, add the Build_Test pipeline and Check_Breaking_Changes pipeline

![GitHub Logo](/ReadMeImages/BuildValidationSetup.png)


12. Create the initial checkBreakingChangesTag on branch main (if it isn't already present). 

    git tag checkBreakingChanges (creates local tag)

    git push --tag checkBreakingChanges (creates remote tag)

    git tag -d checkBreakingChanges (deletes local tag)

    git push --delete origin checkBreakingChanges (deletes remote tag)


13. Run Check_Breaking_Changes pipeline manually, on branch main with an Ubuntu agent
14. Run Build_Test pipeline manually, on branch main with windows-2019 agent
15. Once Build_Test completes successfully, the Update_CheckBreakingChange_Location pipeline should trigger and run successfully
16. Breaking changes will not be able to be merged into master. The Check_Breaking_Changes pipeline will fail and tell you exactly what changes would be breaking to a consumer.



# Build and Test
1. Clone
2. Build

# Contribute
Feel free to pick up where I left off!

# References
<br>
buf.build
<br>
https://docs.brew.sh/
<br>
https://grpc.io/
<br>
