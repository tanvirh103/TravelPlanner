'use client'
import Link from "next/link";
import { useRouter } from "next/navigation";

export default function Dashbaord(){
  const router = useRouter();
  const handleLogout = () => {
    localStorage.removeItem("Session");
    router.push("/");
  };
    return(
        <>
        <div className="flex justify-center items-center min-h-screen bg-gray-100">
        <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
          <h1 className="text-2xl font-bold mb-6 text-center">Dashboard</h1>
          <div className="space-y-4">
            <Link href="/Trip/CreateTrip">
              <button className="w-full bg-blue-500 text-black py-2 rounded-md hover:bg-blue-600 transition">
                Create Trip
              </button>
              <br/>
            </Link><br/>
            <Link href="/Trip/GetAllTrip">
              <button className="w-full bg-purple-500 text-black py-2 rounded-md hover:bg-purple-600 transition">
                View All Trips
              </button>
              <br/>
            </Link>
            <br/>
            <Link href="UserList">
              <button className="w-full bg-green-500 text-black py-2 rounded-md hover:bg-green-600 transition">
                Get All Users
              </button>
              <br/>
            </Link><br/>
            <Link href="/Budget/CreateBudget">
              <button className="w-full bg-indigo-400 text-black py-2 rounded-md hover:bg-indigo-600 transition">
                Create Budget
              </button>
              <br/>
            </Link>
            <br/>
            <Link href="/Budget/GetAllBudget">
              <button className="w-full bg-teal-400 text-black py-2 rounded-md hover:bg-teal-600 transition">
                View All Budget
              </button>
              <br/>
            </Link>
            <br/>
            <Link href="/Packing/CreatePacking">
              <button className="w-full bg-orange-400 text-black py-2 rounded-md hover:bg-orange-600 transition">
                Create Packing
              </button>
              <br/>
            </Link>
            <br/>
            <Link href="/Packing/GetAllPacking">
              <button className="w-full bg-gray-400 text-black py-2 rounded-md hover:bg-gray-600 transition">
                View All Packing
              </button>
              <br/>
            </Link>
            <br/>
            <br/>
          </div>
        <button
              className="w-full bg-yellow-400 text-black py-2 rounded-md hover:bg-yellow-600 transition"
              onClick={handleLogout}
            >
              Logout
            </button>
        </div>       
        </div>       
        </>
    );

}