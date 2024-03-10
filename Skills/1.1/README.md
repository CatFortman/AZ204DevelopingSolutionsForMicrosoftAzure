## Step 1
Create a VM without remote access
1. Register an application in your azure subscription
2. Create a service policy on your application
3. Update the azureauth.properties file with your Azure subscription parameters
4. Use the dotnet run command in this skill folder to execute Program1
   
## Step 2
Create a VM with remote access
1. Comment out Program1
2. Uncomment Program2
3. Use the dotnet run command in this skill folder to execute Program2
   
## Step 3
Deploy a vm using an arm template
1. Review the vm arm template in the ArmTemplates folder 
2. Modify the vm-deployment-parameters.json file in the ArmTemplateParameters folder with your prefered values
3. Run the each command in the deploy-vm.bat script in Scripts folder
   
## Step 4
Create container images for solutions by using Docker
1. Download Docker Desktop: https://www.docker.com/products/docker-desktop/
2. Review dockerfile in the ContainerExample/Dockerfile folder
3. Open a command line at the ContainerExample directory
4. Execute the following command 
   1. 'docker build --tag=skill1.1:0.1 .'
5. Execute the following command to esnure your docker image has been created
   1. 'docker image ls'
6. Open DockerDesktop and view the skill1.1 image in your Images tab. Your image Name should be skill1.1 and the Tag should be version 0.1.
7. Click the play button in the Actions column to run your container.
8. You should see 'Hello, World!' in the Logs tab. 
   