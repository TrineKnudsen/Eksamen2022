import http from "./http.client";
import type {User} from "@/models/User";

export class UserService{
    async login(email:string,password:string): Promise<User> {
        const res = await http.post<User>("/users/login", {
            email: email,
            password: password
        });
        return res.data;
    }
}