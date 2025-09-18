import {useTemplates} from "../../hooks/useTemplates";
import TemplateCard from "../../components/template/TemplateCard";
import "./TemplatesPage.css";
import {FormEvent, useState} from "react";

export default function TemplatesPage() {
    const { templates, addTemplate, loading, error } = useTemplates();

    const [name, setName] = useState("");
    const [htmlContent, setHtmlContent] = useState("");
    const [submitError, setSubmitError] = useState<string | null>(null);

    if (loading) return <p>Loading...</p>;
    if (error) return <p className="error">Error: {error}</p>;

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
        setSubmitError(null);

        try {
            const res = await fetch("https://localhost:7226/api/templates", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ name, htmlContent }),
            });

            if (!res.ok) throw new Error("Failed to fetch templates.");

            const newTemplate = await res.json();
            addTemplate(newTemplate);
            setName("");
            setHtmlContent("");
        } catch (err: any) {
            setSubmitError(err.message);
        }
    }

    const exampleHtml = `
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Example Template</title>
<style>
  body { font-family: Arial, sans-serif; background-color: #f0f4f8; padding: 1rem; }
  h1 { color: #1e40af; }
  p { color: #111827; font-size: 16px; }
  .highlight { background-color: #fde68a; padding: 0.2rem 0.5rem; border-radius: 4px; }
  .footer { margin-top: 2rem; font-size: 12px; color: #6b7280; text-align: center; }
</style>
</head>
<body>
  <h1>Hello, {{Name}}!</h1>
  <p>This is an <span class="highlight">example template</span> with styled content.</p>
  <div class="footer">Footer text here</div>
</body>
</html>
`.trim();

    return (
        <div className="templates-page">
            <h1>Templates</h1>

            <div className="templates-container">
                <div className="templates-list">
                    {templates.length === 0 ? (
                        <p>No templates available.</p>
                    ) : (
                        templates.map(template => <TemplateCard  key={template.id} template={template}/>)
                    )}
                </div>

                <div className="templates-panel">
                    <h2>Create Template</h2>
                    <p className="warning">
                        ⚠️ HTML content should be a **full HTML document**
                        with &lt;html&gt;, &lt;head&gt;, &lt;body&gt;.
                    </p>
                    <form onSubmit={handleSubmit} className="template-form">
                        <label>
                            Name:
                            <input
                                type="text"
                                value={name}
                                onChange={e => setName(e.target.value)}
                                required
                            />
                        </label>

                        <label>
                            HTML Content:
                            <textarea
                                value={htmlContent}
                                onChange={e => setHtmlContent(e.target.value)}
                                rows={17}
                                required
                                placeholder={exampleHtml}
                            />
                        </label>

                        <button type="submit">Create</button>
                        {submitError && <p className="error">{submitError}</p>}
                    </form>
                </div>
            </div>
        </div>
    )
}