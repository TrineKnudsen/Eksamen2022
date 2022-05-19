pipeline {
    agent any
    triggers {
        pollSCM("* * * * *")
    }
    stages {
        stage ("Build") {
            parallel {
                stage("Build api"){
        when {
        anyOf {
        changeset "SOSU2022_BackEnd/SOSU2022_BackEnd.Domain"
        changeset "SOSU2022_BackEnd/SOSU2022_BackEnd.Core"
        changeset "SOSU2022_BackEnd/SOSU2022_BackEnd.DataAccess"
        changeset "SOSU2022_BackEnd/SOSU2022_BackEnd.WepApi"
        }
        }
 
            steps {
                sh "dotnet build SOSU2022_BackEnd/SOSU2022_BackEnd.sln"
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