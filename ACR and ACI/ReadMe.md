
# keep the docker file out side of the .proj folder
# make sure docker desktop is running by 
	docker ps

# build the application and create the image
# docker build -t[tag] [imageName]:version . - 
	docker build -t messagepublisher:latest .

# to push the image to ACR
# pre req you need Azure CLI installed login to Azure portal
	az login

# make sure resource and container registry created in Azure portal 
# check the available images, once step 2 ececuted you can see your image name
	docker images

# login in to docker ACR -> access key- > enable adminUser 
# docker login [ACR login server]
	docker login ajeesh.azurecr.io

# docker tagging
# docker tag [ImageID] [acrloginserver]/[ImageName]
	docker tag e19318645734 ajeesh.azurecr.io/messagepublisher 

# push image to ACR
# docker push [tagname]
	docker push ajeesh.azurecr.io/messagepublisher 

# create AKS cluster 
	az aks create \
	--resource-group FirstAKS \
	--name messagepublishercluster \
	--node-count 1 \
	--generate-ssh-keys \
	--attach-acr ajeesh

# get credential
    az aks get-credentials --resource-group FirstAKS --name messagepublishercluster

# if namespace not there create one
    kubectl create namespace milestone

# set to the namespace as current context
    kubectl config set-context --current --namespace=milestone


# create the Yaml file for deployment
# run below comment for execution
# kubectl apply -f [yamlfilename]
	kubectl apply -f deployment.yaml

# to check status
	kubectl get pods
    kubectl describe pods
    kubectl log [podName]

# helm deployment

# install helm cli
	choco install kubernetes-helm
	helm create deployment

# helm template check
	helm template deployment deployment

# to install
    helm install [reelaseName] deployment
	helm install deployment deployment
    helm install deployment deployment --values [path to the value file]

# to check the version
	helm list

# to update the deployment
	helm upgrade deployment deployment
    helm upgrade $(ReleaseName) $(ChartFolderPath) --atomic --install --force --values $(ValuesFolderPath) --namespace $(AuditSPSNamespace)
    helm upgrade release01 deployment --atomic --install --force --values deployment\value.yaml --namespace milestone
    helm rollback release01 --namespace milestone

# To list the releases / history
    helm ls -a -n milestone
    helm history <release> --namespace <namespace>

# helm Uninstall
    helm uninstall [releaseName]

