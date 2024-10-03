import axios from "axios";
import Link from "next/link";

interface User{
    UserId: number;
    UserName: string;
    Email:string;
    CreatedAt:string
    
}
process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';

export default async function UserList(){
    const res=await axios.get(process.env.Net_Api+"/User/GetAll");
    const Users:User[]=await res.data;
    return(
         <div className="flex justify-center items-center min-h-screen bg-gray-100">
            <div className="bg-white p-6 rounded-lg shadow-md w-full max-w-4xl">
        <h1 className="text-2xl font-bold mb-6 text-center">List Of Users</h1>
        <table className="min-w-full border-collapse border border-slate-400">
          <thead>
            <tr className="bg-gray-200">
              <th className="border border-slate-300 px-4 py-2 text-left">User ID</th>
              <th className="border border-slate-300 px-4 py-2 text-left">User Name</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Email</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Join Date</th>
            </tr>
          </thead>
          <tbody>
            {Users.map((User) => (
            
              <tr key={User.UserId} className="even:bg-gray-50 odd:bg-white">
                <td className="border border-slate-300 px-4 py-2">{User.UserId}</td>
                <td className="border border-slate-300 px-4 py-2">{User.UserName}</td>
                <td className="border border-slate-300 px-4 py-2">{User.Email}</td>
                <td className="border border-slate-300 px-4 py-2">{User.CreatedAt}</td>
              </tr>
              
            ))}
          </tbody>
        </table>
        </div>
        </div>
    );
}