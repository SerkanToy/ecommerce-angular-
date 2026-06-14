export interface UserModel {
    name: string;
    jwt: string;
    mfaToken: string;
}

export interface AuthstatusModel{
    isAuthenticated: boolean;
}