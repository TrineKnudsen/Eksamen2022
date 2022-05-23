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
    stage("Clean containers"){
        steps{
            script {
                sh "docker-compose down"
            }
        }
    }
    stage("Deploy"){
        steps{
            sh "docker-compose -d"
        }
    }
}}