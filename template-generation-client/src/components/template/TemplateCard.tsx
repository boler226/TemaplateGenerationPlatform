import {Template} from "../../api/templates";
import "./TemplateCard.css";

interface Props {
    template: Template;
}



export default function TemplateCard({ template }: Props) {
    const handleDelete = async () => {
        if (!confirm("Видалити шаблон?")) return;

        try {
            const res = await fetch(`https://localhost:7226/api/templates/${template.id}`, {
                method: "DELETE",
            });

            if (!res.ok) throw new Error("Не вдалося видалити шаблон");

            window.location.reload();
        } catch (err: any) {
            alert(err.message);
        }
    };

    const handleDownload = async () => {
        try {
            const res = await fetch(`https://localhost:7226/api/templates/${template.id}/generate`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ Name: template.name, Data: "" }),
            });

            if (!res.ok) throw new Error("Не вдалося згенерувати PDF");

            const pdfBytes = await res.arrayBuffer();
            const blob = new Blob([pdfBytes], { type: "application/pdf" });
            const url = URL.createObjectURL(blob);
            const link = document.createElement("a");
            link.href = url;
            link.download = `${template.name}.pdf`;
            link.click();
            URL.revokeObjectURL(url);
        } catch (err: any) {
            alert(err.message);
        }
    };

    return(
        <div className="template-card">
            <div className="template-card-header">
                <h2>{template.name}</h2>
                <div className="template-card-buttons">
                    <button className="btn btn-download" onClick={handleDownload}>Download PDF</button>
                    <button className="btn btn-delete" onClick={handleDelete}>Delete</button>
                </div>
            </div>

            <div className="template-card-content">
                {template.htmlContent}
            </div>

            <div className="template-card-body">
                <p>Created: {new Date(template.createdAt).toLocaleDateString()}</p>
                <p>Updated: {new Date(template.updatedAt).toLocaleDateString()}</p>
            </div>
        </div>
    )
}