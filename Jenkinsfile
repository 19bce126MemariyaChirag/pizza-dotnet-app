pipeline {
    agent any
    environment {
        APP_NAME = "my-pizza-dotnet-app"
        APP_PORT = "5001"
        IMAGE_TAG = "latest"
        DOCKER_REGISTRY="memariyachirag126"
        
    }
    stages {
        stage('Build') {
            steps {
                
                // Build the project
                sh 'dotnet build'
            }
        }
        stage('test') {
            steps {
                
                // test the project
                sh 'dotnet test'
            }
        }
        stage('pulbish'){
            steps{
                // Publish the project
                sh 'dotnet publish -c Release -o ./publish'
            }
        }
        stage('Docker Build') {
            steps {
                // Build Docker image
                script {
                    docker.build("${DOCKER_REGISTRY}/${APP_NAME}:${IMAGE_TAG}", "--build-arg APP_PORT=${APP_PORT} .")
                }
            }
        }
        stage('Docker Login and Push') {
            steps {
                // Log in to Docker registry
                withCredentials([usernamePassword(credentialsId: 'docker-token', passwordVariable: 'DOCKER_PASSWORD', usernameVariable: 'DOCKER_USERNAME')]) {
                    sh "docker login -u ${DOCKER_USERNAME} -p ${DOCKER_PASSWORD}"
                    sh "docker push ${DOCKER_REGISTRY}/${APP_NAME}:${IMAGE_TAG}"
                }
            }
        }
    }
}