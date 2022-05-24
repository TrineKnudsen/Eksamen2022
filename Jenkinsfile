pipeline {
    agent any
    triggers {
        pollSCM("* * * * *")
    }

    environment {
        COMMITMSG = sh(returnStdout: true, script: "git log -1 --oneline")
    }
    stages {
        stage ("Startup"){
        steps{
        buildDescription env.COMMITMSG
        }
        }
        
        stage ("Build") {
            parallel {
                stage("Build api"){
                steps{
                sh"echo 'We are building the api'"
                dir("SOSU2022_BackEnd"){
                sh "dotnet build SOSU2022_BackEnd.sln"
                }
            }
            post {
                always{
                    sh "echo 'Building API finished'"
                }
                success{
                sh "echo 'Building API succeeded'"
                }
                failure {
                sh "echo 'Building API failed'"
                }
                
            }
                }
            }
        
            
    }
    stage ("Test"){
        steps {
            dir("SOSU2022_BackEnd/SOSU2022_BackEnd.Domain.Test"){
                sh "dotnet add package coverlet.collector"
                sh "dotnet test --collect:'XPlat Code Coverage'"
            }
            dir("SOSU2022_BackEnd/SOSU2022_BackEnd.Core.Test"){
                            sh "dotnet add package coverlet.collector"
                            sh "dotnet test --collect:'XPlat Code Coverage'"
                        }
        }
        post {
            success{
                publishCoverage adapters: [coberturaAdapter('SOSU2022_BackEnd/SOSU2022_BackEnd.Domain.Test/TestResults/*/coverage.cobertura.xml')]
                publishCoverage adapters: [coberturaAdapter('SOSU2022_BackEnd/SOSU2022_BackEnd.Core.Test/TestResults/*/coverage.cobertura.xml')]
                
                                            
                            }
        }
    }
    stage("Clean containers"){
        steps{
            script {
                sh "docker rm -f sosu-web-container"
                sh "docker rm -f sosu-api-container-back"
            }
        }
    }
    stage("Deploy"){
        parallel {
            stage("Frontend"){
                steps{
                    dir("sosu-frontend"){
                        sh "docker build -t sosu-image ."
                        sh "docker run --name sosu-web-container -d -p 8082:80 sosu-image"
                    }
                }
            }
            stage("API"){
                steps{
                    dir("SOSU2022_BackEnd/SOSU2022_BackEnd.WebApi"){
                        sh "docker build -t sosu-api2022 ."
                        sh "docker run --name sosu-api-container-back -d -p 8081:80 sosu-api"
                    }
                }
            }
        }
    }
}}