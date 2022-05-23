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

       
        stage("Build frontend"){
        steps{
            sh"echo 'npm is not working'"
            //dir("sosu-frontend"){
            //sh "npm run build"}
        }
        }
            }
        
            
    }
    stage ("Test"){
        steps {
            dir("SOSU2022_BackEnd/Core.Test/SOSU2022_BackEnd.Core.Test"){
                sh "dotnet add package coverlet.collector"
                sh "dotnet test --collect:'XPlat Code Coverage'"
            }
           
        
        }
        post {
            success{
                publishCoverage adapters: [coberturaAdapter('SOSU2022_BackEnd/Core.Test/SOSU2022_BackEnd.Core.Test/TestResults/*/coverage.cobertura.xml')]
                
                                            
                            }
        }
    }
    stage("Deploy"){
        parallel {
            stage("Frontend"){
                steps{
                    dir("sosu-frontend"){
                        sh "docker build -t sosu-web2022 ."
                        sh "docker run sosu-web2022-container -d -p 8060:80 sosu-web2022"
                    }
                }
            }
            stage("API"){
                steps{
                    dir("SOSU2022_BackEnd"){
                        sh "docker build -t sosu-api ."
                        sh "docker run --name sosu-api-container -d -p 8061:80 sosu-api"
                    }
                }
            }
        }
    }
}}