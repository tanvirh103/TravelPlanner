import axios from "axios";
interface Budget{
    BudgetId: number;
    BudgetItem: string;
    EstimatedCost:number;
    TripId:number;
}
process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';

export default async function GetAllBudget(){
    const res=await axios.get(process.env.Net_Api+"/Budget/GetAll");
    const Budgets:Budget[]=await res.data;
    return(
        <>
         <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div className="bg-white p-6 rounded-lg shadow-md w-full max-w-4xl">
        <h1 className="text-2xl font-bold mb-6 text-center">List Of Budget</h1>
        <table className="min-w-full border-collapse border border-slate-400">
          <thead>
            <tr className="bg-gray-200">
              <th className="border border-slate-300 px-4 py-2 text-left">Budget ID</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Budget Item</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Estimated Cost</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Trip Id</th>
            </tr>
          </thead>
          <tbody>
            {Budgets.map((Budget) => (
              <tr key={Budget.TripId} className="even:bg-gray-50 odd:bg-white">
                <td className="border border-slate-300 px-4 py-2">{Budget.BudgetId}</td>
                <td className="border border-slate-300 px-4 py-2">{Budget.BudgetItem}</td>
                <td className="border border-slate-300 px-4 py-2">{Budget.EstimatedCost}</td>
                <td className="border border-slate-300 px-4 py-2">{Budget.TripId}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
    </>
    );
}