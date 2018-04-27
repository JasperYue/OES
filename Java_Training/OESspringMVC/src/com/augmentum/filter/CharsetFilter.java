package com.augmentum.filter;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebFilter;
import javax.servlet.annotation.WebInitParam;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletRequestWrapper;
import javax.servlet.http.HttpServletResponse;

/**
 * Set charsetEncoding to UTF-8
 */
@WebFilter(urlPatterns = {"/page/*"}, initParams = {@WebInitParam(name = "CharsetEncoding", value = "UTF-8")})
public class CharsetFilter extends HttpFilter {

    /** Request & response's Encoding */
    private String CharsetEncoding = "UTF-8";

    @Override
    protected void init() {
        CharsetEncoding= this.getFilterConfig().getInitParameter("CharsetEncoding");
    }

    @Override
    public void doFilter(HttpServletRequest request,
            HttpServletResponse response, FilterChain chain)throws IOException, ServletException {
        request.setCharacterEncoding(CharsetEncoding);
        response.setCharacterEncoding(CharsetEncoding);

        /** HtmlUtils in Spring can also do this things*/
        // AdvancedRequest requestWrapper = new AdvancedRequest(request);

        chain.doFilter(request, response);
    }

}

class AdvancedRequest extends HttpServletRequestWrapper {
    private HttpServletRequest request;
    private List<String> dirtyWords = new ArrayList<>();

    public AdvancedRequest(HttpServletRequest request) {
        super(request);
        this.request = request;
        dirtyWords.add("fuck");
        dirtyWords.add("f u c k");
    }

    @Override
    public String getParameter(String name) {
        String value = this.request.getParameter(name);
        if (value == null) {
            return null;
        }
        // Pass 1: filtrate dirtyWords
        value = filtration(value);
        // Pass 2: transferred html tag
        return transferred(value);
    }

    private String filtration(String value) {
        for (String dirtyWord : dirtyWords) {
            if (value.contains(dirtyWord)) {
                value = value.replace(dirtyWord, "XXXX");
            }
        }
        return value;
    }

    private String transferred(String value) {
        if (value == null){
            return null;
        }
        char content[] = new char[value.length()];
        value.getChars(0, value.length(), content, 0);
        StringBuffer result = new StringBuffer(content.length + 50);
        for (int i = 0; i < content.length; i++) {
            switch (content[i]) {
                case '<':
                    result.append("&lt;");
                    break;
                case '>':
                    result.append("&gt;");
                    break;
                case '&':
                    if (content[i + 1] == 'g' || content[i + 1] == 'l' || content[i + 1] == 'a' || content[i + 1] == 'q') {
                        result.append(content[i]);
                    }else {
                        result.append("&amp;");
                    }
                    break;
                case '"':
                    result.append("&quot;");
                    break;
                default:
                    result.append(content[i]);
            }
        }
        return result.toString();
    }
}

