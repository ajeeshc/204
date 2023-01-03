	docker build -t messagepublisher:[Tag] .
	docker images
	docker tag a7697f77f987 ajeesh.azurecr.io/net6simpledocker:[Tag]      
	docker push ajeesh.azurecr.io/net6simpledocker:[Tag]     

	kubectl create namespace milestone
	az aks get-credentials --resource-group FirstAKS --name messagepublishercluster
	kubectl config set-context --current --namespace=milestone

	helm create [deploymentfolderName]
	helm template [folder] deployment
	helm install milestonerelease01 deployment
	helm upgrade release01 deployment --atomic --install --values deployment\values.yaml --namespace milestone
	helm rollback milestonerelease01  --namespace milestone
	helm ls -a -n milestone
	helm history milestonerelease01 --namespace milestone

	kubectl get pods
    kubectl describe pods
    kubectl log [podName]