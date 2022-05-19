pipeline {
    agent any
    triggers {
        pollSCM("* * * * *")
    }
    stages {
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
            }
                }

       
        stage("Build frontend"){
        steps{
        sh ""
        }
        }
        
        }       
    }  
}
}