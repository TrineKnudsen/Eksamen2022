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
       dir("SOSU2022_BackEnd/SOSU2022_BackEnd.Domain.Test"){
       sh "rm -rf TestResults"}
       dir("SOSU2022_BackEnd/SOSU2022_BackEnd.Core.Tests"){
       sh "rm -rf TestResults"}
        }
        }
        
        stage ("Build") {
            parallel {
                stage("Build api"){
                steps{
                sh"echo 'We are building the api'"
                dir("SOSU2022_BackEnd"){
           
                sh "dotnet build --configuration Release"
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
                sh "dotnet test --collect:'Xplat Code Coverage'"
            }
            dir("SOSU2022_BackEnd/SOSU2022_BackEnd.Core.Tests"){
                            sh "dotnet add package coverlet.collector"
                            sh "dotnet test --collect:'Xplat Code Coverage'"
                        }
           
        }
        post {
          success {
        publishCoverage adapters: [coberturaAdapter("SOSU2022_BackEnd/SOSU2022_BackEnd.Domain.Test/TestResults/*/coverage.cobertura.xml")]
        publishCoverage adapters: [coberturaAdapter("SOSU2022_BackEnd/SOSU2022_BackEnd.Core.Tests/TestResults/*/coverage.cobertura.xml")]
        }
        }
       
    }
    stage("Clean containers"){
        steps{
            script {
            try {
                sh "docker rm -f sosu-web-container"
                sh "docker rm -f sosu-api-container-back"
                }
                finally { }
            }
        }
    }
    stage("Deploy"){
        parallel {
            stage("Frontend"){
                steps{
                    dir("sosu-frontend"){
                        sh "docker build -t sosu-image2022 ."
                        sh "docker run --name sosu-web-container -d -p 8090:80 sosu-image2022"
                    }
                }
            }
            stage("API"){
                steps{
                    dir("SOSU2022_BackEnd/SOSU2022_BackEnd.WebApi"){
                        sh "docker build -t sosu-api2022 ."
                        sh "docker run --name sosu-api-container-back -d -p 8091:80 sosu-api2022"
                    }
                }
            }
        }
    }
}}