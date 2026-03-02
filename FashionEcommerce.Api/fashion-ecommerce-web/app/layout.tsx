import "./globals.css";
import Navbar from "./components/Navbar";
import { AuthProvider } from "./context/AuthContext";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className="bg-gray-50">
        <AuthProvider>
          <Navbar />
          <div className="pt-20">{children}</div>
        </AuthProvider>
      </body>
    </html>
  );
}