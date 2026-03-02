import "./globals.css";
import Navbar from "./components/Navbar";

export const metadata = {
  title: "Fashion Store",
  description: "Modern Ecommerce Website",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className="bg-gray-50">
        <Navbar />
        <div className="pt-20">{children}</div>
      </body>
    </html>
  );
}