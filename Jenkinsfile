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
        sh ""
        }
        }
            }
        
            
    }
    stage ("Test"){
        steps {
            dir("SOSU2022_BackEnd/SOSU2022_BackEnd.Domain"){
             
            }
        }
    }
    stage("Deploy"){
                steps{
                    dir("sosu-frontend"){
                        sh "docker build -t sosu-web ."
                        sh "docker run --name sosu-web-container-1 -d -p 8070:80 sosu-web"
                    }
                }
    }
}}