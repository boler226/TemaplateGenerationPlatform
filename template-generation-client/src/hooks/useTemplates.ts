import {useEffect, useState} from "react";
import {fetchTemplates, Template} from "../api/templates";

export function useTemplates() {
    const [templates, setTemplates] = useState<Template[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        fetchTemplates()
            .then(setTemplates)
            .catch(err => setError(err.message))
            .finally(() => setLoading(false));
    }, []);

    const addTemplate = (template: Template) => {
        setTemplates([...templates, template]);
    };

    return { templates, addTemplate, loading, error };
}