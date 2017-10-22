﻿using System.IO;
using Antlr4.Runtime;

namespace AtlusScriptLib.MessageScriptLanguage.Compiler.Parser
{
    public static class MessageScriptParserHelper
    {
        public static MessageScriptParser.CompilationUnitContext ParseCompilationUnit( string input, IAntlrErrorListener<IToken> errorListener = null )
        {
            var inputStream = new AntlrInputStream( input );
            return ParseCompilationUnit( inputStream, errorListener );
        }

        public static MessageScriptParser.CompilationUnitContext ParseCompilationUnit( TextReader input, IAntlrErrorListener<IToken> errorListener = null )
        {
            var inputStream = new AntlrInputStream( input );
            return ParseCompilationUnit( inputStream, errorListener );
        }

        public static MessageScriptParser.CompilationUnitContext ParseCompilationUnit( Stream input, IAntlrErrorListener<IToken> errorListener = null )
        {
            var inputStream = new AntlrInputStream( input );
            return ParseCompilationUnit( inputStream, errorListener );
        }

        private static MessageScriptParser.CompilationUnitContext ParseCompilationUnit( AntlrInputStream inputStream, IAntlrErrorListener<IToken> errorListener = null )
        {
            var lexer = new MessageScriptLexer( inputStream );
            var tokenStream = new CommonTokenStream( lexer );

            // parser
            var parser = new MessageScriptParser( tokenStream );
            parser.BuildParseTree = true;
            //parser.ErrorHandler = new BailErrorStrategy();

            if ( errorListener != null )
            {
                parser.RemoveErrorListeners();
                parser.AddErrorListener( errorListener );
            }

            var cst = parser.compilationUnit();

            return cst;
        }
    }
}