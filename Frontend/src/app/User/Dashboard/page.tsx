import Link from "next/link";

export default function Dashbaord(){
    return(
        <>
        <div className="flex justify-center items-center min-h-screen bg-gray-100">
        <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
          <h1 className="text-2xl font-bold mb-6 text-center">Dashboard</h1>
          
          <div className="space-y-4">
            <Link href="/Trip/CreateTrip">
              <button className="w-full bg-blue-500 text-white py-2 rounded-md hover:bg-blue-600 transition">
                Create Trip
              </button>
              <br/>
            </Link><br/>
            <Link href="UserList">
              <button className="w-full bg-green-500 text-white py-2 rounded-md hover:bg-green-600 transition">
                Get All Users
              </button>
              <br/>
            </Link><br/>
            <Link href="/Trip/GetAllTrip">
              <button className="w-full bg-purple-500 text-white py-2 rounded-md hover:bg-purple-600 transition">
                View All Trips
              </button>
              <br/>
            </Link>
            <br/>
            <Link href="/Trip/GetAllTrip">
              <button className="w-full bg-purple-500 text-white py-2 rounded-md hover:bg-purple-600 transition">
                Create Budget
              </button>
              <br/>
            </Link>
          </div>
        </div>
      </div>
        </>
    );

}